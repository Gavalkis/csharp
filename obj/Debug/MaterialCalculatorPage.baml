   M S B A M L   `   `   `  ����L  HmasterAndFloorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:masterAndFloorAppmasterAndFloorApp  5      .    (masterAndFloorApp.MaterialCalculatorPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:masterAndFloorApp     5        N� Title$  MaterialCalculatorPage��5	      .��5      � $��20q�6   $	��Top=�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $ ��Тип продукции:��6   �� 5   
   -   5         ��Name$ ProductTypeComboBox��5      $��0��60   $��	150,0,0,5q�6=   $	��200��6P    �� DisplayMemberPath$ Title��5       �� SelectedValuePath$ ProductTypeID��6-   5       �� 5"   
   $ ��Тип материала:��6   $��1��6*   �� 5#   
   -   5        $ MaterialTypeComboBox��5#      $��1��61   $��	150,0,0,5q�6>   $	��200��6Q   $ Title��5$      $ MaterialTypeID��6-   5%      �� 5'   
   $.��(Количество продукции:��6   $��2��61   �� 5(   
   -   5         ��Name$ QuantityTextBox��5(      $��2��6+   $��	150,0,0,5q�68   $	��200��6K   �� 5*   
   $0��*Коэффициент продукции:��6   $��3��62   �� 5+   
   -   5        $ CoefficientTextBox��5+      $��3��6.   $��	150,0,0,5q�6;   $	��200��6N   �� 5-   
   $3��-Процент брака материала:��6   $��4��64   �� 5.   
   -   5        $ DefectRateTextBox��5.      $��4��6-   $��	150,0,0,5q�6:   $	��200��6M   �� 50   
   -   5        $��5��50      $��Рассчитать��6   $	��120��63   $��30��6?   $��0,10,0,0q�6K   $
��Left=�51      6,   �� 53   
   -   5         ��Name$ ResultTextBlock��53      $��6��6-   $��0,20,0,0q�6:   $
��Bold"�6L   $��14(�54      $
��Wrap=�6"   55      56      