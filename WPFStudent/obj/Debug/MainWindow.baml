   M S B A M L   `   `   `  ����  
WPFStudent    WPFStudent.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   
������ � SizeToContent$ WidthAndHeight=�64    � WindowStartupLocation$ CenterScreen=�6S   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5	      $��6 �6   �� 5
      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��6 �6   �� 5      $
��auto �6   �� 5      $��6 �6   �� 5      $
��auto �6   �� 5      $��6 �6   �� 5      $
��auto �6   �� 5      $��6 �6   �� 5      $
��auto �6   �� 5      $��6 �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   � $��1��6   $��1��6   $
��auto��6,   $
��auto��6:   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��DataGridResults��5         
IsReadOnly .    HeadersVisibility$ Column=�6�      AutoGenerateColumns .     HorizontalGridLinesBrush
 �   �
���   �
���   �$
��Bold"�6M  ��6.   �� *ResultsList+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� SelectedItem
 6w   �� *Result+$	 PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Student Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *StudentName+  5       $ Subject Name��6)    6?   �� *SubjectName+  5!      $ Grade��6)    68   �� *Grade+  5"      $
 Date��6)    67   �� *Date+ �� StringFormat$ 
dd/MM/yyyy��5$      5%      �� 5&   
   -   5        $��btnAddResult��5&   /   $��3��6   $��1��6!   $��
Add Result��6C   $��20��6X   $��80��6d   $
��Bold"�6�   ��6o   �� *AddNewResult+$	 PropertyChanged=�6�   �� 5'   
   -   5        $��btnEditResult��5'   /   $��3��6   $��3��6!   $��Edit Result��6D   $��20��6Z   $��80��6f   $
��Bold"�6�   ��6q   �� *
EditResult+$	 PropertyChanged=�6�   �� 5(   
   -   5        $��btnDeleteResult��5(   /   $��3��6   $��5��6!   $��Delete Result��6F   $��20��6^   $��80��6j   $
��Bold"�6�   ��6u   �� *DeleteResult+$	 PropertyChanged=�6�   �� 5)   
   -   5        $��btnMenageStudent��5)   J   $��1��6   $��7��6!   $
��Left=�6/   $��Menage Student��6b   $��20��6{   $	��100��6�   $
��Bold"�6�   ��6�   �� *MenageStudent+$	 PropertyChanged=�6�   �� 5*   
   -   5        $��btnMenageSubject��5*   K   $��1��6   $��7��6!   $��Right=�6.   $��Menage Subject��6c   $��20��6|   $	��100��6�   $
��Bold"�6�   ��6�   �� *MenageSubject+$	 PropertyChanged=�6�     5+   
   -   5        $��DataGridStudents��5+   D   $��1��6   $��9��6#   $��3��60   $
��auto��6\   $
��auto��6j    . $ Column=�6a   .  $
��Bold"�6�  
 �   �
���   �
���   ���6w   �� *StudentsList+$	 PropertyChanged=�
 6�   �� *	Student+$	 PropertyChanged=�y�6  �� *ViewStudent+$	 PropertyChanged=� 5,        5-      $ Student name��6%    6;   �� *StudentName+  5.      $ Student Surname��6%    6>   �� *StudentSurname+  5/      $ Index Number��6%    6;   �� *IndexNumber+  50      $ 	BirthDate��6%    68   �� *	BirthDate+  51      $	 Sex��6%    62   �� *Sex+  52      $ Adress��6%    65   �� *Adress+54      �� 55   
   $��1��6   $��11��6%    �� Orientation$ 
Horizontal=�63   .+�56      �� -   5        $��btnAddStudent��56   ,   $��80��6   $��20��6    $��Add Student��6A   $��4q�6�   $
��Bold"�6�   y�6W   �� *ViewStudent+$	 PropertyChanged=���6�   �� *AddNewStudent+6�   �� 57      -	   5        $��btnEditStudent��57   ,   $��80��6   $��20��6    $��Edit Student��6B   $
��Bold"�6�   y�6Y   �� *ViewStudent+$	 PropertyChanged=���6�   �� *EditStudent+$	 PropertyChanged=�6�   �� 58      -
   5        $��btnDeleteStudent��58   ,   $��90��6   $��20��6    $��Delete Student��6D   $��4q�6�   $
��Bold"�6�   y�6]   �� *ViewStudent+$	 PropertyChanged=���6�   �� *DeleteStudent+$	 PropertyChanged=�6�   59        5:   
   -   5        $��DataGridSubjects��5:   D   $��1��6   $��9��6#   $��1��60   $
��auto��6\   $
��auto��6j    . $ Column=�6   .  $
��Bold"�6�  
 �   �
���   �
���   ���6w   �� *SubjectsList+$	 PropertyChanged=�
 6�   �� *	Subject+$	 PropertyChanged=�y�64  �� *ViewSubject+$	 PropertyChanged=� 5;        5<         Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6%   $ Subject Name��62    6H   �� *SubjectName+  5=      $
 auto 6%   $ 	Professor��62    6E   �� *	Professor+  5>      $ 80 6%   $ Semestre��60    6B   �� *
Semestre+5@      �� 5A   
   $��1��6   $��11��6%   $ 
Horizontal=�63   .+�5B      �� -   5        $��btnAddSubject��5B   ,   $��80��6   $��20��6    $��Add Subject��6A   $��4q�6�   $
��Bold"�6�   y�6W   �� *ViewSubject+$	 PropertyChanged=���6�   �� *AddNewSubject+6�   �� 5C      -   5        $��btnEditSubject��5C   ,   $��80��6   $��20��6    $��Edit Subject��6B   $
��Bold"�6�   y�6Y   �� *ViewSubject+$	 PropertyChanged=���6�   �� *EditSubject+$	 PropertyChanged=�6�   �� 5D      -   5         ��Name$ btnDeleteSubject��5D   ,   $��90��6   $��20��6    $��Delete Subject��6F   $��4q�6�   $
��Bold"�6�   y�6_   �� *ViewSubject+$	 PropertyChanged=���6�   �� *DeleteSubject+$	 PropertyChanged=�6�   5E      5F      5G      