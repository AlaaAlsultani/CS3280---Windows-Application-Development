   M S B A M L   `   `   `  ����M  ICS3280GroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CS3280GroupProject.SearchCS3280GroupProject.Search  5   	   )    #CS3280GroupProject.Search.wndSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:CS3280GroupProject.Search     5   	     � Title$  Invoice Search��5   	   $��455.98��6    $��695.386��60   ���	#FFC7C7C7 � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6m    � Topmost .  � WindowStartupLocation$ CenterOwner=�6�    � ForceCursor .  � Icon$4 ./CS3280GroupProject;component/InvoiceImage.png��6�   .��5	      � .+�5
   
   �� -   5         ��Name$ SelectInvoiceBtn��5
      $��Select Invoice��6+   $
��Left=�6D   $��536,379,0,0q�6_   $	��Top=�6t   $��85��6�   {�.  6�   �� 5   
   -   5        $ 	CancelBtn��5      $��Cancel��6$   $
��Left=�65   $��428,379,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
    �� Orientation$ Vertical=�6   $��46,10,502,354q�6,   .+�5      �� $��Invoice Number��6   $��-3,0,0,0q�6-   �� 5      -   5        	 ��Name$	 InvoiceNumCmb��5      $
��Left=�6.   $	��Top=�6I   $	��120��6a   6m   5      �� 5   
   $ Vertical=�6   $��185,10,328,354q�6,   .+�5      �� $��Invoice Date��6   �� 5      -   5        $	 InvoiceDateCmb��5      $
��Left=�6/   $	��Top=�6J   $	��164��6b   6n   5      �� 5   
   $ Vertical=�6   $��369,10,188,349q�6,   .+�5      �� $��Invoice Total��6   �� 5      -   5        $	 InvoiceTotalCmb��5      $
��Left=�60   $	��Top=�6K   $	��120��6c   6o   5      &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 InvoiceList��5      $��Stretch=�6(   $	��263��6M   $��
46,76,45,0q�6Z   $	��Top=�6n      AutoGenerateColumns .     SelectionMode$ Single=�5         CanUserResizeRows .     
IsReadOnly .    CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Invoice Number��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 .3* 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ��  �� Path$
 _Num�6[     5      $ Invoice Date��6%   $	 .4* 6Z    6;   �� $ _Date�6Z     5      $ Invoice Total��6%   $	 .3* 6\    6<   �� $ _Total�6\      RowDetailsTemplate 5       �� 5!      .R�5"        $��Stretch=�6    .  $ Single=�6`    .  $
��Auto��6�   $	��537��6�   $��25,0,0,0q�6�    . ��6�   �� *_Items+ 5#        5$      $ 	Item Code��61   $ * 6D    6N   �� $ _Code�  5%      $ 	Item Name��61   $ * 6D    6N   �� $ _Desc�  5&      $ 	Item Cost��61   $ * 6D    6N   �� $ _Cost�5(      5)      5,      �� 5-   
   -   5        $ ClearFilterBtn��5-      $��Clear Filters��6)   $
��Left=�6A   $��
520,34,0,0q�6\   $	��Top=�6p   $��75��6�   {�.  6�   5/      50      