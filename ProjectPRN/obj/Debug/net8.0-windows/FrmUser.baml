   M S B A M L   `   `   `  ����E  AProjectPRN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjectPRN
ProjectPRN  5   	       ProjectPRN.FrmUser   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjectPRN     5   	     � Title$  FrmUser��5   	   $	��450��6   $	��800��6&    � 	Resources 5	         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5
   
   " ��6$   .�5      ��  � ��$ 30��6'   �� 5       � ��$ 80��6&   �� 5       � ��
 � ���6+   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 10��6K   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5!   
   �� $��60,23,5,217q�6   Bài thi chưa làm6;   �� 5"   
   -   5         ��Name$ ExamListBox��5"      	 �� DisplayMemberPath$
	 Name��5#      $��0��5$      $��2��5%      $��
0,45,533,0q�5&      5'      � 5)   
   $��1��6   
 � RowDefinitions
 5*      �� 5+      $��* �6    �� 5,      $��2* �6    .+�5/      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��Center=�6?   $	��115��6\   $	��Top=�6i   $	��526��6�   $��0,10,0,0q�6�   .+�50      �� -   5        $��	Làm bài��50      #��[  6+   $��18(�6P   $��
190,5,38,5q�6|   $	��160��6�   $��30��6�   �� 51      -   5        $��↩️��51      #��[  6&   $��20(�6K   $��27��6n   $��	38,0,0,80q�6z   52      �� 53      $��20,102,-21,187q�6   $��2��60   Bài thi đã hoàn thành6Y   &   System.Windows.Controls.DataGrid  54      -   5          Name$ HistoryDataGrid��54      $��	0,130,0,0q�55      $��2��56         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5:      5;      5<      �� 5=   
   $��Danh sách đề thi��6   $��30(�6+   $
��Bold"�69   
����  �$
��Left=�6]   $��5,8,0,0q�6x   $	��Top=�6�   $��1��6�   5>      5?      