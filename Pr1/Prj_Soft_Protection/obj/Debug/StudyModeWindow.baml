   M S B A M L   `   `   `  ����N  JPrj_Soft_Protection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prj_Soft_ProtectionPrj_Soft_Protection  5	      )    #Prj_Soft_Protection.StudyModeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Kmc<http://schemas.openxmlformats.org/markup- compatibility/2006     5      3local!clr-namespace:Prj_Soft_Protection     5	        � Title$.  (Вікно режиму навчання��5
      $��296.267��6   $��325.6��60   $��16(�5      $��Courier New)�6   $
��Bold"�6(    � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�6&   .��5      � ���	#FFBEF0E2$��0,0,0,0q�6"    � ColumnDefinitions 5   
   �� 5      $
��113* �6   �� 5      $	��41* �6   .+�5   
   �� $!��РЕЖИМ НАВЧАННЯ��6   $
��Left=�6)   $��8,10,0,0q�5      $	��Top=�6   $��28��6+   $	��297��5      $��Center=�6   $��18(�5      $��2��6   �� 5   
   -   5         ��Name$ 
VerifField��5      $
��Left=�6(   $��
171,44,0,0q�5      $
��Wrap=�6   $	��Top=�5      $��22��6   $	��125��6%    �� TextAlignment$ Justify=�5      ���	#FF764F22$�� ��5      $��2��6	   �� 5   
   -   5         ��Name$ 
InputField��5      $
��Left=�6&   $��28��5      $��	8,141,0,0q�6    �� TextWrapping$
 Wrap=�6    $	��Top=�5       $	��212��6   ���	#FFDBE6F9$��Stretch=�5!      6;   �� 5#   
   $'��!Поле для введення:��6   $
��Left=�6-   $��	8,108,0,0q�5$      $	��Top=�6   $��28��6,   $	��205��5%      $
��Left=�6   $��18(�6/   �� 5'   
   -   5         ��Name$ CloseStudyMode��5'      $ ��Вийти з режиму��6)   $
��Left=�5)      $��
11,212,0,0q�6   $	��Top=�5*      $	��295��6   $��35��6%   $��2��6N   �� 5,   
   $��Кодове слово:��6   $
��Left=�6(   $��8,38,0,0q�5-      $	��Top=�6   $��28��6+   $	��155��5.      $
��Left=�6   $��18(�6/   �� 5/   
   $$��Кількість спроб:��6   $
��Left=�6+   $��	9,174,0,0q�50      $	��Top=�6   $��28��6,   $	��191��51      $
��Left=�6   $��18(�6/   �� 52   
   -   5        	 ��Name$	 CountProtection��52      $
��Left=�6,   $��205,178,0,0q�53      $	��Top=�6   $��55��6.   
 �� SelectedIndex$
 0��54      $��2��6   .@�56      �� $��3��6   �� 57      $��4��6   �� 58      $��5��6   �� 59      $��6��6   �� 5:      $��7��6   �� 5;      5<      �� 5=   
   $3��-Кількість введених симв:��6   $
��Left=�5>      $��8,71,0,0q�6   $	��Top=�5?      $��28��6   $	��270��6%   $
��Left=�5@      $��18(�6#   $��2��61   �� 5B   
   -   5         ��Name$ SymbolCount��5B      $��0��6%   $
��Left=�5D      $��218,108,0,0q�6   $	��Top=�5E      $��28��6   $��37��6%   $��18(�60   $��2��6>   5G      5H      