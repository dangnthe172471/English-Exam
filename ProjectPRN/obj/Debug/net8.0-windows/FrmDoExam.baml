   M S B A M L   `   `   `  ����E  AProjectPRN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjectPRN
ProjectPRN  5   	       ProjectPRN.FrmDoExam   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjectPRN     5   	     � Title$  	FrmDoExam��5   	   $	��500��6   $	��800��6(    � 	Resources 5	         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%h  &	        �� 5
   
   " ��6$   .�5      ��  � ��$ 20(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$	 120��6&   �� 5       � ��$ 50��6'   �� 5       � ��$ Center=�64   �� 5       � ��$ 20q�6'   �� 5       � �� �	#FFB0FDF06+   �� 5       � ��
 �   �6+   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 10��6K   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $��* �6   �� 5$      $
��Auto �6   .+�5'   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��10q�69   .+�5(      �� -   5        	 ��Name$	 TimerTextBlock��5(      $��20(�60   $
��Bold"�6>   $��	680,0,0,0q�6P   �� 5)      -   5        $	 QuestionNumberTextBlock��5)      $��20(�69   $
��Bold"�6G   �� 5*      -   5        $	 QuestionPromptTextBlock��5*      $��25(�69   $
��Wrap=�6G   $��	0,10,0,10q�6[   �� 5+      -   5        $	 QuestionContentTextBlock��5+      $��20(�6:   $
��Wrap=�6H   $��	0,10,0,10q�6\   5,      �� 5.   
   $��1��6   $��	10,10,0,5q�6"   .+�5/      	� -   5        
 	�Name$
 Answer1RadioButton��5/      $��20(�66    	� 	GroupName$ Answers��6D   $��Answer 1��6X   $��0,5,0,5q�6k   $��Center=�6|   	� 50      -   5        $
 Answer2RadioButton��50      $��20(�66   $ Answers��6D   $��Answer 2��6X   $��0,5,0,5q�6k   $��Center=�6|   	� 51      -   5        $
 Answer3RadioButton��51      $��20(�66   $ Answers��6D   $��Answer 3��6X   $��0,5,0,5q�6k   $��Center=�6|   	� 52      -   5        $
 Answer4RadioButton��52      $��20(�66   $ Answers��6D   $��Answer 4��6X   $��0,5,0,5q�6k   $��Center=�6|   53      �� 54   
   $ 
Horizontal=�6   $��1��6.   $��0,189,10,10q�6;   $��Right=�6P   $	��790��6l   .+�55      �� -	   5        #��[  55      $��Previous��6:   $��250,20,20,20q�6j   �� 56      -
   5        #��[  56      $
��Next��6:   6I   �� 57      -   5        #��[  57      $��Submit��6:   $��
100,38,0,0q�6f   ���	#FFB1F9A06z   58      59      5:      