   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	   5clr-namespace:Library.ViewModelLibrary.ViewModel  5   	       Library.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	   5	viewModelclr-namespace:Library.ViewModel     5   	     � WindowState$  	Maximized=�5	   	    � Title$ Library��5
   	   $
��1080��6   $
��1920��6'    � 	Resources 5      ��%    5       � DataContext 5      %  Library.ViewModel.MainViewModel  5   
   .��5      �� ���	#FF1E1E1E._�5   
   �  � LayoutTransform 5      �� 5       �� ScaleX$	 0.8Q�6!    �� ScaleY$	 0.8Q�6.    � ColumnDefinitions 5      �� 5      $	��350 �6#   61   �� 5      6%    � RowDefinitions 5      �� 5      $	��145 �6    6/   �� 5      6"   .+�5      �� ���#393939$��
0, 0, 1, 0q�6+   ._�5       �� $��Fonts/Inder.ttf#Inder)�6   $
��Left=�6?   $��
100,85,0,0q�6Z   $
��Wrap=�6n   $��Library��6�   $	��Top=�6�   
�������$��48(�6�   	 J� RenderTransformOrigin$	 0.505,0.063&�6�   5!      �� 5"      $��0��6   $��1��6%   ���#393939$��
0, 0, 1, 0q�6H   ._�5#      �� $
��Left=�6   $	��Top=�68   .+�5$      	� ���	#FF2C2C2C���	#FF2C2C2C   radiobut#��[  6Q   $��	5,130,0,0q�6s   
 d� 	IsChecked$

 TrueY�6�   ��6�   �� *MyFilesViewCommand+.��5%      ��  �� Orientation$ 
Horizontal=�6%   .+�5&      F�   icon#��[ 6#   $��20,0,0,0q�6]   ��6A   �� *
MyFilesBut+6]   �� 5'      $��15,0,0,0q�6(   ��6:   �� *
MyFilesBut+�� 6]   $�My Files��6a   6t   5(      5)      	� 5*      ���	#FF1E1E1E���	#FF1E1E1E#��[  6Q   $��5,0,0,0q�6s   ��6�   �� *BookmarksViewCommand+.��5+      �� $ 
Horizontal=�6%   .+�5,      F� #��[ 6#   $��20,0,0,0q�6_   ��6A   �� *BookmarksBut+6_   �� 5-      $��15,0,0,0q�6(   ��6:   �� *BookmarksBut+�� 6_   $�	Bookmarks��6c   6w   5.      5/      	� 50      #��[  6#   $��5,0,0,0q�6E   ��6V   �� *FavouritesViewCommand+.��51      �� $ 
Horizontal=�6%   .+�52      F�   fav#��[ 6#   $��20,0,0,0q�6_   ��6@   �� *FavouritesBut+6_   �� 53      $��15,0,0,0q�6(   ��6:   �� *FavouritesBut+�� 6`   $�
Favourites��6d   6y   54      55      56      57      �� 59      $��1��6   $��0��6(   $��Fonts/Inder.ttf#Inder)�65   $
��Left=�6X   $��	75,85,0,0q�6s   $	��Top=�6�   
�������$��48(�6�   $	 0.505,0.063&�6�   ��6�   �� *CurrentText+6�   >� 5:      $��1��6   $��1��6*   $��	0,130,0,0q�67   ��6J   �� *CurrentView+5<      5=      5>      5?      