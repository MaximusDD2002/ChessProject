using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AICore;

namespace ChessProblemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        int curentIndex = 0;
        BitmapImage king = new BitmapImage(new Uri("/Pieces/King.png", UriKind.Relative));
        BitmapImage rook = new BitmapImage(new Uri("/Pieces/Rook.png", UriKind.Relative));
        BitmapImage bishop = new BitmapImage(new Uri("/Pieces/Bishop.png", UriKind.Relative));
        ChessProblemNode actualNode = new ChessProblemNode();
        List<ChessProblemNode> solutionList = new List<ChessProblemNode>();
        GraphSearchChessProblem curentAlg;
        public MainWindow()
        {
            solutionList.Add(actualNode);
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawChessBoard(actualNode);
        }

        private void DrawChessBoard(ChessProblemNode node)
        {
            ChessProblemState state = node.State;
            char[,] pieces = state.GetState;
            ChessBoard.Children.Clear();
            int n = state.GetXLength;
            int m = state.GetYLength;
                
            double step = (ChessBoard.ActualWidth / (m - 2) < ChessBoard.ActualHeight / (n - 2)) 
                            ? ChessBoard.ActualWidth / (m - 2)
                            : ChessBoard.ActualHeight/ (n - 2);

            //Drawing squares on the board
            for (int i = 1; i < n-1; i++)
            {
                double topMargin = (i-1) * step;
                for (int j = 1; j < m-1; j++)
                {
                    double leftMargin = (j-1) * step;
                    if ((i + j) % 2 == 0)
                    {
                        ChessBoard.Children.Add(
                            new Rectangle()
                            {
                                Fill = new SolidColorBrush(Colors.DarkGray),
                                Margin = new Thickness(leftMargin, topMargin, 0, 0),
                                Height = step,
                                Width = step
                            }
                        );
                    }

                    BitmapImage image = new BitmapImage();
                    switch (pieces[i,j])
                    {
                        case 'K':
                            image = king;
                            break;
                        case 'R':
                            image = rook;
                            break;
                        case 'B':
                            image = bishop;
                            break;
                        default:
                            break;
                    }

                    ChessBoard.Children.Add(
                        new Image()
                        {
                            Source = image,
                            Width = step - 10,
                            Height = step - 10,
                            VerticalAlignment = VerticalAlignment.Top,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Margin = new Thickness(leftMargin, topMargin, 0, 0)
                        }
                    );
                }
            }
        }


        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (ComboAlgorithm.SelectedIndex == 0) chooseAlg(rnd.Next(ComboAlgorithm.Items.Count-1) + 1);

            actualNode = curentAlg.Search();
            solutionList = curentAlg.GetSolutionAsList(actualNode);
            DrawChessBoard(actualNode);
            curentIndex = solutionList.Count-1;
            LblIndex.Content = curentIndex;
        }

        private void ComboAlgorithm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chooseAlg(ComboAlgorithm.SelectedIndex);
        }

        private void chooseAlg(int x)
        {
            switch (x)
            {
                case 1: //Backtrack
                    curentAlg = new BacktrackChessProblem(true);
                    break;
                case 2: //Depthfirst
                    curentAlg = new DepthFirstChessProblem();
                    break;
                case 3: //Breadthfirst
                    curentAlg = new BreadthFirstChessProblem();
                    break;
                default:
                    break;
            }
        }

        private void BtnIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (++curentIndex > solutionList.Count - 1) curentIndex = solutionList.Count - 1;
            LblIndex.Content = curentIndex;
            DrawChessBoard(solutionList[curentIndex]);
        }

        private void BtnDecrease_Click(object sender, RoutedEventArgs e)
        {
            if (--curentIndex < 0) curentIndex = 0;
            LblIndex.Content = curentIndex;
            DrawChessBoard(solutionList[curentIndex]);
        }
    }
}
