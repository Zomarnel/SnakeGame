   M S B A M L   `   `   `  ����@  <WPFUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPFUI.ViewModelsWPFUI.ViewModels  5   	       WPFUI.UI.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5
viewModelsclr-namespace:WPFUI.ViewModels     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5   	   -   5          � WindowStartupLocation$  CenterScreen=�5
   	    � 
ResizeMode$ NoResize=�5   	    � Title$ 	Snakegame��5   	   $	��627��6   $	��584��6(    � Icon$ /Images/Snakegame.ico��5       J� Opacity$ 50Q�5   	   .��5      �� .+�5   
   �� -   5         ��Name$ CanvasPlayGround��5   "    �� Left$ 30��6    �� Bottom$ 30��6<   $	��510��6O   $	��450��6[    K� ZIndex$ 99��6h   �� 5   
   -   5        $ CanvasPlayGroundGrid��5   "   $ 30��6   $ 30��6@   $	��510��6S   $	��450��6_   $ 1��6l   �� 5   
   $ 0��6   $ 0��6!   $	��570��63   $	��510��6?   ���#578a346L   �� 5   
   $ 0��6   $	 510��6!   $	��570��65   $��80��6A   ���#4a752c.+�5      � 	 � ColumnDefinitions	 5      �� 5      $	��150 �6'   �� 5      $	��150 �6'   .+�5      �� $��0��6   $��30, 20, 15, 0q�6(   $
��Left=�6?   $��Center=�6Z   $��40��6�   $��40��6�   "  WpfAnimatedGif.ImageBehavior
   AnimatedSource
 6u   �� *FruitImageUri+6�   �� 5      $��0��6   $��40, 20, 12, 0q�6(   $��Center=�6?   $��Center=�6c   
�������$
��17pt(�6�   ��6�   �� *CurrentScore+6�   �� 5      $��1��6   $��30, 20, 15, 0q�6(   $
��Left=�6?   $��Center=�6Z   $ ��/Images/Helpers/trophy.png��6u   $��40��6�   $��40��6�   �� 5       $��1��6   $��40, 20, 12, 0q�6(   $��Center=�6?   $��Center=�6c   
�������$
��17pt(�6�   ��6�   �� *GameSettings.Record+6�   5"      5#      5$      5%      