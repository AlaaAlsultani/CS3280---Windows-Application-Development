   M S B A M L   `   `   `  ����C  ?CS3280A5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CS3280A5CS3280A5  5   	       CS3280A5.UserInfoForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CS3280A5     5   	   -   5          �Name$  PlayerDetails��5   	    � Title$ Player Details��5   	   $	��350��6    $	��525��6-    � Icon$ ../Images/dirtblock.png��69    � 
ResizeMode$ NoResize=�6X    � WindowStartupLocation$ CenterScreen=�6n   .��5	      � ��5
   
   �� 5       �� ImageSource$D >../Images/minecraft_dirt_wallpaper_by_thedevartist-d3l1qoj.png��6   .+�5   
   �� -   5         ��Name$ NameEntryBox��5      $
��Left=�6(   $��37��6C   $��
167,50,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��199��6�    
  MCFont#��[  6�   $��22(�6�   $��8,6,0,0q�6�   ���	#FF5D483E
������� �� 	MaxLength$ 20��6  �� 5   
   -   5        	 ��Name$	 NameEntryLabel��5      $��Name :
��6(   $
��Left=�6>   $��	61,50,0,0q�6Y   $	��Top=�6l   #��[  6�   $��37��6�   $��87��6�   $��24(�6�   
�������6�   �� 5   
   -   5        $	 AgeEntryLabel��5      $��Age :��6'   $
��Left=�67   $��
83,149,0,0q�6R   $	��Top=�6f   #��[  6~   $��37��6�   $��65��6�   $��24(�6�   
�������6�   �� 5   
   -   5        $ AgeEntryBox��5      $
��Left=�6'   $��37��6B   $��167,149,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��63��6�   #��[  6�   $��22(�6�   $��8,6,0,0q�6�   ���	#FF5D483E
�������$ 3��6  6  �� 5   
   $
��Left=�6   $	��206��6+   $��
384,65,0,0q�68   $	��Top=�6L   $	��109��6d   $��../Images/MCSteve.png��6p   �� 5   
   -   5        
 ��Name$
 PlayerInfoBtn��5      $
��Left=�6(   $��201,245,0,0q�6C   $	��Top=�6X   $	��121��6p   $��34��6|     ButtonStyle#��[ 6�   ���	#FFABADB3$��1q�6�   ���	#FF5D483E.��5      �� $��24��6   $	��119��6%    �� Orientation$ 
Horizontal=�61   .+�5      �� $��Uniform=�6   $��../Images/DiamondPick.png��6*   $��30��6M   $��28��6X   �� 5      $��Submit��6   $��88��6*   $��16(�65   #��[  6C    �� Padding$ 10,4,0,0q�6c   
�������6v   5      5      �� 5   
   -   5        $	 AgeEntryErrLbl��5      $�� ��6(   $
��Left=�63   $��167,191,0,0q�6N   $	��Top=�6c   ���	#FFF53C3C J� RenderTransformOrigin$ 	0.506,0.1&�6�   5      5      