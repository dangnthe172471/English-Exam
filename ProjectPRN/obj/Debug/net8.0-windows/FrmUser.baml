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
   �� 5      $��* �6   �� 5      $��2* �6   .+�5"   
   �� -   5         ��Name$ ExamListBox��5"      	 �� DisplayMemberPath$
	 Name��6'   $��0��6@   $��2��6P   $��
0,45,533,0q�6d   � 5$   
   $��1��6   
 � RowDefinitions
 5%      �� 5&      $��* �6    �� 5'      $��2* �6    .+�5*      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��Center=�6?   $	��115��6\   $	��Top=�6i   $	��526��6�   $��0,10,0,0q�6�   .+�5+      �� -   5        $��	Làm bài��5+      #��[  6+   $��18(�6P   $��
190,5,38,5q�6|   $	��160��6�   $��30��6�   �� 5,      -   5        $��↩️��5,      #��[  6&   $��20(�6K   $��27��6n   $��	38,0,0,80q�6z   5-      &   System.Windows.Controls.DataGrid  5/      -   5          Name$ HistoryDataGrid��5/      $��	0,130,0,0q�60   $��2��6C      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   50      �� 51   
   $��Danh sách đề thi��6   $��30(�6+   $
��Bold"�69   
����  �$
��Left=�6]   $��
242,-6,0,0q�6x   $	��Top=�6�   $��2��6�   52      53      