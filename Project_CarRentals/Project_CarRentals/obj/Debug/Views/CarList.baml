   M S B A M L   `   `   `  ����M  IProject_CarRentals, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Project_CarRentals.ViewsProject_CarRentals.Views  5      7 clr-namespace:Project_CarRentalsProject_CarRentals  5      &     Project_CarRentals.Views.CarList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Project_CarRentals.Views     5      ?Project_CarRentals clr-namespace:Project_CarRentals     5        N� Title$  CarList��5
      $	��800��6   $	��450��6#    � 	Resources 5      )   #Project_CarRentals.CarRentalDataSet   carRentalDataSet  carsViewSource �� Source �� Source  ButtonRoundedCorner �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        &	      7   &	 =       5   
   6.   �� 5   
    66   �� *Cars+8   �� 5   
   " ��6,   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 10��6!   #��z��63   $��2q�6]   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      5      .��5      � 	 � DataContext#	 [ 6   .+�5   
   �� ���	#FF252422$
��Left=�6%   $	��450��6@   ���	#00000000$	��Top=�6`   $	��800��6x   �� 5    
   $
��Left=�6   $��
327,22,0,0q�6/   $
��Wrap=�6C   $��List of cars��6W   $	��Top=�6k   $��30(�6�   ���	#FFFFFCF2$��Rockwell)�6�   &   System.Windows.Controls.DataGrid  5"   
   -   5        
  Name$
 carsDataGrid��5"      $   HorizontalScrollBarVisibility$ Hidden=�6)   "   VerticalScrollBarVisibility$
 Auto=�6P      AutoGenerateColumns .     EnableRowVirtualization . $��0,75,0,0q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ���	#FF252422���	#FF403D39���	#00EB5E28$��Center=�6N  $	��Top=�6k  $	��800��6�  $	��292��6�     MinColumnWidth$ 61Q�6�  ��6�   ��    Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      -   5        carIdColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Car Id��5$   T      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *CarId+6v     5%      -   5        brandColumn��$ Brand��5%   T   $ SizeToHeader 6c    6:   �� *Brand+6c     5&      -   5        modelColumn��$ Model��5&   T   $ SizeToHeader 6c    6:   �� *Model+6c     5'      -   5        
typeColumn��$
 Type��5'   R   $ SizeToHeader 6`    69   �� *Type+6`     5(      -   5        carYearColumn��$ Car Year��5(   X   $ SizeToHeader 6j    6<   �� *	CarYear+6j     5)      -   5        fuelTypeColumn��$ 	Fuel Type��5)   Z   $ SizeToHeader 6m    6=   �� *
FuelType+6m     5*      -   5        mileageColumn��$ Mileage��5*   X   $ SizeToHeader 6i    6<   �� *	Mileage+6i     5+      -	   5        availabilityColumn��$ Availability��5+   b   $ SizeToHeader 6x    6A   �� *Availability+6x     5,      -
   5        pricePerKmColumn��$ Price Per Km��5,   ^   $ SizeToHeader 6t    6?   �� *
PricePerKm+6t     5-      -   5        pricePerHourColumn��$ Price Per Hour��5-   b   $ SizeToHeader 6z    6A   �� *PricePerHour+6z     5.      -   5        pricePerDayColumn��$ Price Per Day��5.   `   $ SizeToHeader 6w    6@   �� *PricePerDay+6w     5/      -   5        userIdColumn��$ User Id��5/   V   $ SizeToHeader 6g    6;   �� *UserId+6g   51      �� 52   
   -   5        #��[ 52      $��Go back��6>   $
��Left=�6P   $��194,388,0,0q�6k   $	��Top=�6�   $	��100��6�   $��10(�6�   ���	#FFEB5E28$��27��6�   6�   �� 53   
   -   5        #��[ 53      $��Go list of users��6>   $
��Left=�6Y   $��414,388,0,0q�6t   $	��Top=�6�   $	��100��6�   ���	#FFEB5E28$��10(�6�   $��27��6�   6�   �� 54   
   -   5        #��[ 54      $��Go list of rentals��6>   $
��Left=�6[   $��524,388,0,0q�6v   $	��Top=�6�   $	��100��6�   ���	#FF403D39$��10(�6�   $��27��6�   6�   �� 55   
   -   5        #��[ 55      $��Go list of payments��6>   $
��Left=�6\   $��304,388,0,0q�6w   $	��Top=�6�   $	��100��6�   ���	#FF403D39$��10(�6�   $��27��6�   6�   56      57      