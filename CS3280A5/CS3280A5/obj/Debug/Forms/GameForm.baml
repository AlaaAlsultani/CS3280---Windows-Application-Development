   M S B A M L   `   `   `  ����C  ?CS3280A5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CS3280A5CS3280A5  5   	       CS3280A5.GameForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CS3280A5     5   	   -   5          �Name$  	GameForm1��5   	    � Title$ Minecraft Math��5   	   $	��350��6    $	��525��6-    � Icon$ ../Images/dirtblock.png��69    � 
ResizeMode$ NoResize=�6X    � WindowStartupLocation$ CenterScreen=�6n   .��5	      � -   5         �Name$ AnswerLabel��5	       � ColumnDefinitions 5
   
   �� 5      $	��26* �6   �� 5      $	��66* �6   �� 5      $	��56* �6   �� 5      $	��62* �6   �� 5      $	��46* �6   �� 5      $
��110* �6   �� 5      $
��118* �6   ��5   
   �� 5       �� ImageSource$D >../Images/minecraft_dirt_wallpaper_by_thedevartist-d3l1qoj.png��6   .+�5   
   �� -   5         ��Name$ 	Num1Label��5      $�� ��6#   $��Right=�6.   $��	0,121,0,0q�6J   $	��Top=�6]   
������� 
  MCFont#��[  6�   $��36(�6�   $��67��6�   $��1��6�   $��Right=�6�   �� 5   
   -   5        	 ��Name$	 OperatorImage��5      $��19,131,16,152q�6'   $��../Images/PlusSign.png��6>   
 J� RenderTransformOrigin$
 0.593,0.325&�6^   $��2��6�   �� 5   
   -   5        $ 	Num2Label��5      $�� ��6#   $
��Left=�6.   $��	3,121,0,0q�6I   $	��Top=�6\   
�������#��[  6�   $��36(�6�   $��54��6�   $��3��6�   $
��Left=�6�   �� 5   
   -   5        $ 
EqualLabel��5      $��=��6$   $
��Left=�60   $��	6,119,0,0q�6K   $	��Top=�6^   
�������#��[  6�   $��36(�6�   $��4��6�   �� 5   
   -   5         ��Name$ AnswerInputBox��5       �� TextWrapping$
 Wrap=�6*   ���	#FF5D483E���	#FFABADB3$��16,121,10,144q�6m   
�������$��36(�6�   $��8,4,0,0q�6�    �� SelectionBrush
 �����#��[  6�    �� 	MaxLength$ 3��6�    �� IsUndoEnabled . $��5��6  6>  �� 5   
   -   5         ��Name$ SubAnswerBtn��5      $��6��6'   $
��Left=�67   $��
14,128,0,0q�6R   $	��Top=�6f   $��84��6~   $��32��6�   $��16(�6�     ButtonStyle#��[ 6�   
���������5      �� 5      $4 ./CS3280A5;component/Images/MCButtonTexture.png��6   .��5      �� $��Submit��6   #��[  6&   5       �� 5!   
   -	   5        $ TimerLbl��5!      $��0��6"   $��6��6.   $
��Left=�6>   $��	71,19,0,0q�6Y   $	��Top=�6l   $��46��6�   $��37��6�   
�������$��24(�6�   $
 0.622,0.478&�6�   �� 5"   
   -
   5        $ TimeLbl��5"      $��Time :��6!   $��6��62   $
��Left=�6B   $��	18,26,0,0q�6]   $	��Top=�6p   
�������$��16(�6�   �� 5#   
   -   5        $ MainMenuBtn��5#      $��1��6&   $
��Left=�66   $��	4,255,0,0q�6Q   $	��Top=�6d   $	��217��6|   $��45��6�   $��16(�6�   #��[ 6�   
�������$��4��6�   ��5$      �� 5%      $4 ./CS3280A5;component/Images/MCButtonTexture.png��6   .��5'      ��  �� Orientation$ 
Horizontal=�6   $	��207��62   $��35��6>   .+�5(      �� $+��%/CS3280A5;component/Images/MCDoor.png��6   $��45��6G   �� 5)      $��Exit To Main Menu��6   #��[  65   $��Right=�6U   $	��150��6q   $��	0,10,12,7q�6}   5*      5+      � 5,   
   -   5         �Name$ RoundProgressBar��5,      $��6��60   $
��Left=�6@   $��10��6[   $��	36,70,0,0q�6g   $	��Top=�6z   $��81��6�   ���	#FF0074FF6�   �� 5-   
   -   5        $ GameMaxCountLbl��5-      $	��/10��6)   $��6��67   $
��Left=�6G   $��	10,61,0,0q�6b   $	��Top=�6u   
�������$��31��6�   �� 5.   
   -   5        $ CurrentRoundLbl��5.      $��0��6)   $��5��65   $
��Left=�6E   $��
112,61,0,0q�6`   $	��Top=�6t   
�������$��2��6�   $��24��6�   $��Right=�6�   5/      50      