   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5       
WeatherApp   WeatherApp.WeatherMap   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      
���   �.��5
      �   � ColumnDefinitions  5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $	��11* �6   6+   �� 5      $
��139* �6   6,   .+�5   
   '   !Microsoft.Maps.MapControl.WPF.Map  -   5          Name$	 Map��5      +   %Microsoft.Maps.MapControl.WPF.MapCore   CredentialsProviderT   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$r lkdZJmZ4vgujbABzslMTx~LJdezJEfoUd_AGfouXIjRg~AgDg1zk0AZwHJIi709KW2T97_JL8p5AJS8szvnwdLyFQRNMyc0bfsVGJUBnxIve9 6      Center<   6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$	 0,0 6�      	ZoomLevel$ 2Q�6�   $��1��6�   $��0��6�   $��5��6�   $��1��6�   $��Stretch=�6�   $��Stretch=�6     Mode;   5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$ Aerial 6J     Children. 5      +   %Microsoft.Maps.MapControl.WPF.Pushpin  -   5          Name$	 Pin��5      5      	� 5   
   -   5        	 	�Name$	 Clouds��5      $��0��6&   $��0��63   $��Center=�6C   $��Center=�6^   
�������$��Clouds��6�   	� 5   
   -   5        $
	 Temp��5      $��0��6$   $��1��61   $��Center=�6A   $��Center=�6\   $��Temperature��6�   
�������6�   	� 5   
   -   5        $	 Precipation��5      $��0��6+   $��2��68   $��Center=�6H   $��Center=�6c   $��Precipitation��6�   
�������6�   	� 5   
   -   5        $	 Pressure��5      $��0��6(   $��3��65   $��Center=�6E   $��Center=�6`   $��Pressure��6�   
�������6�   	� 5   
   -   5        $
	 Wind��5      $��0��6$   $��4��61   $��Center=�6A   $��Center=�6\   $��
Wind Speed��6�   
�������6�   5      5      