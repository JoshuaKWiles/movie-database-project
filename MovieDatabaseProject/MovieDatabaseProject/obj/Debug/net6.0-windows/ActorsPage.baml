   M S B A M L   `   `   `  ����O  KMovieDatabaseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MovieDatabaseProjectMovieDatabaseProject  5      %    MovieDatabaseProject.ActorsPage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:MovieDatabaseProject     5        N� Title$  
ActorsPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6    � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��5* �6   �� 5      $��5* �6   �� 5      $��5* �6   �� 5      $��5* �6   �� 5      $��5* �6   .+�5   
   �� -   5         ��Name$ movie_title��5      $��0��6)   $��1��66   $��4��6F   $��Center=�6Z   $��Bottom=�6w   $��30(�6�   $��*Movie Name* Actors��6�   $��0,0,0,10q�6�   � 5$   
   $��1��6   $��1��6   $��4��6,   $��4��6@    5%      �� 5&      $��* �6#   �� 5'      $��* �6#   �� 5(      $��* �6#   �� 5)      $��* �6#    5+      �� 5,      $	��12* �6    �� 5-      $��* �6    �� 5.      $	��12* �6    �� 5/      $��* �6    .+�51      �� -   5         ��Name$ actor1��51      $��0��6)   $��0��66   $��Stretch=�6F   
���iii�$��5 0 5 0q�6y   .+�52      �� -   5         ��Name$ actor1Photo��52      $I��Chttps://www.thefamouspeople.com/profiles/thumbs/ryan-reynolds-5.jpg��6-   $��400px��6z   $��Uniform=�6�   �� 53      -   5        $ 
actor1Name��53      $
��Bold"�60   $��Bottom=�6B   $��Center=�6]   $��Ryan Reynolds��6z   
�������$
��20px��6�    �� Padding$ 0 0 0 10q�6�   $
��Wrap=�6�   54      �� 56      -   5        $ actor2��56      $��0��6)   $��1��66   $��Stretch=�6F   
���iii�$��5 0 5 0q�6y   .+�57      �� -   5        $ actor2Photo��57      $I��Chttps://www.thefamouspeople.com/profiles/thumbs/harrison-ford-2.jpg��6-   $��400px��6z   $��Uniform=�6�   �� 58      -   5        $ 
actor2Name��58      $
��Bold"�60   $��Bottom=�6B   $��Center=�6]   $��Harrison Ford��6z   
�������$
��20px��6�   $ 0 0 0 10q�6�   $
��Wrap=�6�   59      �� 5;      -   5        $ actor3��5;      $��0��6)   $��2��66   $��Stretch=�6F   
���iii�$��5 0 5 0q�6y   .+�5<      �� -	   5        $ actor3Photo��5<      $G��Ahttps://www.thefamouspeople.com/profiles/thumbs/halle-berry-3.jpg��6-   $��400px��6x   $��Uniform=�6�   �� 5=      -
   5        $ 
actor3Name��5=      $
��Bold"�60   $��Bottom=�6B   $��Center=�6]   $��Halle Berry��6z   
�������$
��20px��6�   $ 0 0 0 10q�6�   $
��Wrap=�6�   5>      �� 5@      -   5        $ actor4��5@      $��0��6)   $��3��66   $��Stretch=�6F   
���iii�$��5 0 5 0q�6y   .+�5A      �� -   5        $ actor4Photo��5A      $H��Bhttps://www.thefamouspeople.com/profiles/thumbs/nicolas-cage-3.jpg��6-   $��400px��6y   $��Uniform=�6�   �� 5B      -   5        $ 
actor4Name��5B      $
��Bold"�60   $��Bottom=�6B   $��Center=�6]   $��Nicolas Cage��6z   
�������$
��20px��6�   $ 0 0 0 10q�6�   $
��Wrap=�6�   5C      �� 5E      -   5        $ actor5��5E      $��2��6)   $��0��66   $��Stretch=�6F   
���iii�$��5 0 5 0q�6y   .+�5F      �� -   5        $ actor5Photo��5F      $D��>https://www.thefamouspeople.com/profiles/thumbs/emma-stone.jpg��6-   $��400px��6u   $��Uniform=�6�   �� 5G      -   5        $ 
actor5Name��5G      $
��Bold"�60   $��Bottom=�6B   $��Center=�6]   $��
Emma Stone��6z   
�������$
��20px��6�   $ 0 0 0 10q�6�   $
��Wrap=�6�   5H      �� 5J      -   5        $ actor6��5J      $��2��6)   $��1��66   $��Stretch=�6F   
���iii�$��5 0 5 0q�6y   .+�5K      �� -   5        $ actor6Photo��5K      $I��Chttps://www.thefamouspeople.com/profiles/thumbs/marlon-brando-9.jpg��6-   $��400px��6z   $��Uniform=�6�   �� 5L      -   5        $ 
actor6Name��5L      $
��Bold"�60   $��Bottom=�6B   $��Center=�6]   $��Marlon Brando��6z   
�������$
��20px��6�   $ 0 0 0 10q�6�   $
��Wrap=�6�   5M      �� 5O      -   5        $ actor7��5O      $��2��6)   $��2��66   $��Stretch=�6F   
���iii�$��5 0 5 0q�6y   .+�5P      �� -   5        $ actor7Photo��5P      $H��Bhttps://www.thefamouspeople.com/profiles/thumbs/danny-devito-4.jpg��6-   $��400px��6y   $��Uniform=�6�   �� 5Q      -   5        $ 
actor7Name��5Q      $
��Bold"�60   $��Bottom=�6B   $��Center=�6]   $��Danny Devito��6z   
�������$
��20px��6�   $ 0 0 0 10q�6�   $
��Wrap=�6�   5R      �� 5T      -   5        $ actor8��5T      $��2��6)   $��3��66   $��Stretch=�6F   
���iii�$��5 0 5 0q�6y   .+�5U      �� -   5        $ actor8Photo��5U      $G��Ahttps://www.thefamouspeople.com/profiles/thumbs/betty-white-1.jpg��6-   $��400px��6x   $��Uniform=�6�   �� 5V      -   5        $ 
actor8Name��5V      $
��Bold"�60   $��Bottom=�6B   $��Center=�6]   $��Betty White��6z   
�������$
��20px��6�   $ 0 0 0 10q�6�   $
��Wrap=�6�   5W      5X      5[      5\      