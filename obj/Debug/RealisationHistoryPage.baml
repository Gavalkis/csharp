   M S B A M L   `   `   `  ����L  HmasterAndFloorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:masterAndFloorAppmasterAndFloorApp  5      .    (masterAndFloorApp.RealisationHistoryPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:masterAndFloorApp     5      -   5          N� Title$  RealisationHistoryPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��7* �6   �� 5      $��* �6   .+�5   
   �� $O��IИстория реализации продукции партнером��6   $��Center=�6B   $	��Top=�6_   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0��6.   $��10q�6;   .+�5      �  � Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��IsFilter��5   -    d� 	IsChecked$ FalseY�6   6?   �� 5      $��Фильтровать��6   5      �� 5      $(��"Выберите партнера:��6   �� 5      -   5        $��
CBPartners��5      $	��200��5       �� DisplayMemberPath$ Title��5       �� SelectedValuePath$ 	PartnerID��5      �� 5       $��Дата от:��6   (  "System.Windows.Controls.DatePicker  5!      -   5        $��DPStartDate��5!      $	��150��6,   $	��5,0q�68   �� 5"      $��Дата до:��6     5#      -   5        $��	DPEndDate��5#      $	��150��6*   $	��5,0q�66   �� 5$      -   5        $��Фильтровать��5$      $	��100��6C   $	��5,0q�6O   5%      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ DGridPartnerProducts��5'         AutoGenerateColumns .  $��1��6M   	   Columns	 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Номер��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *PartnerProductsID+  5*      $
 Продукция��6%    68   �� *Product.Title+  5+      $
 Партнер��6%    66   �� *Partner.Title+  5,      $
 Количество��6%    69   �� *
Quantity+  5-      $
 Дата��6%    63   �� *Date+ �� StringFormat$ 
dd.MM.yyyy��4  .System.Windows.Controls.DataGridTemplateColumn  5.         CellTemplate 5/      �� 50      .R�51      ��  ��Name$ BtnEdit��6%   -   5        $��Изменить��51   6   6a   52      54      56      �� 58   
   -	   5        $��	DeleteBtn��58   0   $��Удалить��6   $��2��6#   $
��Left=�6A   $��40��6\      ButtonTemplate#��[  6�   �� 59   
   -
   5        $ 	BtnCreate��59      $��Создать��6$   $��2��6N   $��Right=�6[   6y   5:      5;      