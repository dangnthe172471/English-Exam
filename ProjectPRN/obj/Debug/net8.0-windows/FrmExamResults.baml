   M S B A M L   `   `   `  ����E  AProjectPRN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjectPRN
ProjectPRN  5   	       ProjectPRN.FrmExamResults   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjectPRN     5   	     � Title$  FrmExamResults��5   	   $	��400��6    $	��800��6-    � 	Resources 5	         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%a  &	        �� 5
   
   " ��6$   .�5      ��  � ��$ 22(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 80��6&   �� 5       � ��$ 38��6'   �� 5       � ��$ Center=�64   �� 5       � ��$ 20q�6'   �� 5       � ��
 � ���6+   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 10��6K   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5       � .+�5!   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ResultDataGrid��5!         AutoGenerateColumns$ False��6+   $��0,58,0,0q�6G   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6Y   
   Columns
 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *STT+  5$      $ QuestionPropmt��6%    6=   �� *QuestionPropmt+  5%      $ Content��6%    66   �� *QuestionContent+  5&      $ Your Answer��6%    6:   �� *
UserAnswer+  5'      $ Correct Answer��6%    6=   �� *CorrectAnswer+  5(      $ Result��6%    65   �� *Result+5*      � 5+   
   $��	0,0,0,303q�6   .+�5,      �� $��Điểm của bạn: ��6   $��20(�6-   $��	125,0,0,0q�6;   �� 5-      $��18(�64   $
��Bold"�6B   $��0,8,0,0q�6T   ��6   �� *
TotalScore+6T   �� 5.      $�� (��6   $��18(�6"   $
��Bold"�60   $��0,8,0,0q�6B   �� 5/      -   5         ��Name$ 
txtCorrect��5/      $��18(�6,   $
��Bold"�6:   $��0,8,0,0q�6L   �� 50      $��/��6   $��18(�6!   $
��Bold"�6/   $��0,8,0,0q�6A   �� 51      -   5        $ txtTotal��51      $��18(�6*   $
��Bold"�68   $��0,8,0,0q�6J   �� 52      $��)��6   $��18(�6!   $
��Bold"�6/   $��0,8,0,0q�6A   �� 53      -   5        #��[  53      $��Thoát��6:   $��	250,5,0,0q�6J   6]   54      55      56      