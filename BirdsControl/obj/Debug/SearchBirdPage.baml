   M S B A M L   `   `   `  ����G  CBirdsControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BirdsControlBirdsControl  5      !    BirdsControl.SearchBirdPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:BirdsControl     5        N� Title$  SearchBirdPage��5	      .��5      � .+�5   
   �� -   5         ��Name$ species_label��5      $��	Species: ��6'   $
��Left=�6;   $��	24,93,0,0q�6V   $	��Top=�5       J� RenderTransformOrigin$ -3.882,-0.268&�6(   $��77��6N   $��16(�6Y   $��Microsoft New Tai Lue)�5      $��34��63   �� 5   
   -   5         ��Name$ speciesComboBox��5      $
��Left=�5      $��
176,98,0,0q�5      $	��Top=�5      $	��150��5      .@�5      �� $��American Gouldian��6   �� 5      $��European Gouldian��6   �� 5      $��Australian Gouldian��6   5      �� 5   
   -   5        $ id_label��5      $
��Id: ��6"   $
��Left=�61   $��
24,136,0,0q�6L   $	��Top=�5      $ -3.882,-0.268&�6(   $	��114��6N   $��16(�6Z   $��Microsoft New Tai Lue)�5      $��33��63   �� 5   
   -   5         ��Name$ id_tb��5      $
��Left=�6!   $��176,141,0,0q�6<    �� TextWrapping$
 Wrap=�6Q   $�� ��6e   $	��Top=�5      $	��150��6*   $��16(�66   $��Microsoft New Tai Lue)�6D   $��24��6g   �� 5   
   -   5        $ hatch_label��5      $��Hatch Date: ��6%   $
��Left=�6<   $��
24,182,0,0q�6W   $	��Top=�5      $ -3.882,-0.268&�6(   $	��111��6N   $��16(�6Z   $��Microsoft New Tai Lue)�5      $��32��63   (  "System.Windows.Controls.DatePicker  5    
   -   5          Name$ 
datePicker��5       $
��Left=�6)   $��176,184,0,0q�6D   $	��Top=�6Y   $	��150��5!      $��26��6!   �� 5"   
   -   5        $ 	sex_label��5"      $��Sex: ��6#   $
��Left=�63   $��
24,227,0,0q�6N   $	��Top=�5#      $ -3.882,-0.268&�6(   $��77��6N   $��16(�6Y   $��Microsoft New Tai Lue)�5$      $��34��63   �� 5%   
   -   5        $ sexComboBox��5%      $
��Left=�5&      $��174,225,0,0q�5'      $	��Top=�5(      $	��150��5)      .@�5*      �� $
��Male��6   �� 5+      $��Female��6   5,      �� 5-   
   -	   5        $ 
cage_label��5-      $��Cage Number: ��6$   $
��Left=�6<   $��
24,271,0,0q�6W   $	��Top=�5.      $ -3.882,-0.268&�6(   $	��124��6N   $��16(�6Z   $��Microsoft New Tai Lue)�5/      $��34��63   �� 50   
   -
   5        $ cage_tb��50      $
��Left=�6#   $��176,276,0,0q�6>   $
 Wrap=�6S   $�� ��6g   $	��Top=�51      $	��150��6*   $��16(�66   $��Microsoft New Tai Lue)�6D   $ 0.896,0.491&�52      $��24��66   �� 53   
   -   5         ��Name$ Search_bird��53      $��Search Bird��6&   $
��Left=�6<   $��220,320,0,0q�6W   $	��Top=�54      $	��106��6)   $��30��6O   &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ gridBird��56      
������ $��Center=�6>   $��	0,355,0,0q�6[   $	��750��6n   6z   �� 57   
   -   5        $ label��57      $��Search Bird��6   $��35(�65   $
��Left=�6C   $��	24,10,0,0q�6^   $	��Top=�6q   $��64��6�   $	��238��6�   �� 58   
   $��/birds3.png��6   $��488,28,11,100q�6%   59      5:      