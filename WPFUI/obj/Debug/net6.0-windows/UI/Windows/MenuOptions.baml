   M S B A M L   `   `   `  ����@  <WPFUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPFUI.ViewModelsWPFUI.ViewModels  5   	   "    WPFUI.UI.Windows.MenuOptions   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   5
viewModelsclr-namespace:WPFUI.ViewModels     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	     � WindowStartupLocation$  CenterOwner=�5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   $	��450��5   	   $	��350��6   $
��15pt(�5   	   
������  � AllowsTransparency$
 True��5   	    � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �� CornerRadius��%�   &	        �� 5   
   " ��6$   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $	 Border��6!   
����  �$
 10��6C   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $
��Auto �6   .+�5&   
   �� $��0��6   
�������$
 10��65   � 5(   
   $��0��6    5*      �� 5+      $��* �6    �� 5,      $��* �6    �� 5-      $��* �6    �� 5.      $��* �6    .+�51      �� -   5        $��NumbersOfFruits��52   -   $��Hidden=�51      $��Hidden=�6J   
����ح�$��0��52   D   ��53      �� 54      .R�55      �  K� IsItemsHost$
 True��6$   56      .@�59      �� $��80��6   $��70��6*   .��5:      �� $"��/Images/Numbers/OneApple.png��6   5;      �� 5<      $��80��6   $��70��6*   .��5=      �� $#��/Images/Numbers/TwoApples.png��6   5>      �� 5?      $��80��6   $��70��6*   .��5@      �� $%��/Images/Numbers/ThreeApples.png��6   5A      �� 5B      $��80��6   $��70��6*   .��5C      �� $$��/Images/Numbers/FourApples.png��6   5D      �� 5E      $��80��6   $��70��6*   .��5F      �� $$��/Images/Numbers/FiveApples.png��6   5G      5I      �� 5K      -   5        $��
FruitTypes��5K   -   
����ح�$��1��6?   $��Disabled=�5L      $��Disabled=�6L   $��0,5,0,0q�5M      ��5N      �� 5O      .R�5P      � $
 True��6$   5Q      .@�5T      �� $��80��6   $��70��6*   .��5U      �� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /Images/Fruits/Apple.gif��6   5V      �� 5W      $��80��6   $��70��6*   .��5X      �� $ /Images/Fruits/Banana.gif��6   5Y      �� 5Z      $��80��6   $��70��6*   .��5[      �� $" /Images/Fruits/Pineapple.gif��6   5\      �� 5]      $��80��6   $��65��6*   .��5^      �� $ /Images/Fruits/Cherry.gif��6   $��Center=�6Y   5_      �� 5`      $��80��6   $��70��6*   .��5a      �� $# /Images/Fruits/Watermelon.gif��6   5b      5d      �� 5f      -   5        $��SnakeColours��5f   -   
����ح�$��2��6A   $��0,5,0,0q�6N   $��Disabled=�5g      $��Disabled=�6L   ��5h      �� 5i      .R�5j      � $
 True��6$   5k      .@�5n      �� $��80��6   $��85��6*   .��5o      �� $��/Images/SnakeGame.ico��6   $��Center=�6;   5p      �� 5q      $��80��6   $��85��6*   .��5r      �� $%��/Images/SnakeIcons/RedSnake.png��6   5s      �� 5t      $��80��6   $��85��6*   .��5u      �� $&�� /Images/SnakeIcons/BlueSnake.png��6   5v      �� 5w      $��80��6   $��85��6*   .��5x      �� $(��"/Images/SnakeIcons/YellowSnake.png��6   5y      5z      �� 5|      -   5        $��
SnakeSpeed��5|   -   
����ح�$��3��6?   $��0,5,0,0q�6L   $��Disabled=�5}      $��Disabled=�6L   ��5~      �� 5      .R�5�      � $
 True��6$   5�      .@�5�      �� $��80��6   $	��115��6*   .��5�      �� $&�� /Images/SnakeSpeeds/Tortoise.png��6   5�      �� 5�      $��80��6   $	��115��6*   .��5�      �� $#��/Images/SnakeSpeeds/Snake.png��6   5�      �� 5�      $��80��6   $	��115��6*   .��5�      �� $$��/Images/SnakeSpeeds/Rabbit.png��6   5�      5�      5�      � 5�   
   $��1��6    � ColumnDefinitions 5�      �� 5�      $��* �6#   �� 5�      $
��Auto �6#   .+�5�      �� -   5        #��[  5�      $��0��5�      $��
0, 5, 5, 0q�5�      
���������5�      � 5�       5�      �� 5�      $��80 �6/   �� 5�      $��* �6/   .+�5�      �� $��0��6    $%��/Images/Helpers/ReturnArrow.png��60   $��50��6Y   $��50��6e   $��Center=�6p   �� 5�      $��1��6    $��Return��60   $��Center=�6A   $��Center=�6e   
�������6�   5�      5�      �� 5�      -   5        #��[  5�      $��1��5�      $��
5, 5, 0, 0q�5�      
�������$	��100��5�      $��75��6"   ��5�      �� 5�      $��/Images/Helpers/Dice.png��6   $��Center=�6>   $��50��6[   $��50��6g   5�      5�      5�      5�      