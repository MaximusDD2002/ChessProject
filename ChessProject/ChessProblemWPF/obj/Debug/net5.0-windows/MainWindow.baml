   M S B A M L   `   `   `  ����J  FChessProblemWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ChessProblemWPFChessProblemWPF  5   	        ChessProblemWPF.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ChessProblemWPF     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $	��400��5	   	   $	��400��5
   	   .��5      � -   5         �Name$ Screen��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5        $ Controls��5      $��0��5      .+�5      �� -   5         ��Name$ BtnDecrease��5      $��<��6*   $��5,5,0,5q�5      $
��Left=�5      $	��Top=�60   ��5      ��  �� RelativeSource �� *Self+ �� Path$ ActualHeight�5   C   �� 5      -   5        $ BtnIncrease��5      $��>��6*   $��30,5,0,0q�5      $
��Left=�5      $	��Top=�60   ��5      ��  �� *Self+$ ActualHeight�5   C   �� 5      -   5         ��Name$ LblIndex��5      $��0��6&   $��60,2,0,0q�5      $
��Left=�5       $	��Top=�6/   �� 5"      -   5         ��Name$ ComboAlgorithm��5"      $��0,5,50,0q�5#      $��Right=�5$      $	��Top=�63   $	��120��5%       �� SelectedIndex$ 0��5&      .@�5(      �� -   5        $��Random��5(      $��Random��6/   �� 5)      -	   5        $��	Backtrack��5)      $��	Backtrack��62   �� 5*      -
   5        $��
DepthFirst��5*      $��
DepthFirst��63   �� 5+      -   5        $��BreadthFirst��5+      $��BreadthFirst��65   5,      �� 5-      -   5        $ BtnStart��5-      $��Start��6'   $��0,5,5,0q�5.      $��Right=�5/      $	��Top=�61   6I   50      �� 52   
   -   5        	 ��Name$	 
ChessBoard��52      $��1��53      $
��Auto��54      $
��Auto��6   $��0,0,0,0q�6,   55      57      58      