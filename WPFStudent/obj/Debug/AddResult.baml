   M S B A M L   `   `   `  ����E  AWPFStudent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPFStudent.ViewModelsWPFStudent.ViewModels  5   	       WPFStudent.AddResult   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5local#clr-namespace:WPFStudent.ViewModels     5   	     � Title$  	AddResult��5   	   $	��300��6   $	��300��6(    � DataContext 5      .  (WPFStudent.ViewModels.AddResultViewModel  5   
   6%   .��5	      � .+�5
   
   �� -   5        $��
cmbStudent��5
   B   $
��Left=�6   $��
113,21,0,0q�6.    �� DisplayMemberPath$ StudentName��6T    �� 
IsEditable .  $	��Top=�6  $	��120��60  ��6�   �� *StudentsList+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *	Student+$ PropertyChanged=�60  �� 5   
   -   5        $��lblvalidName��5      $��*��6$   ���	#FFFB0000$��20(�6H   $��233,16,-233,-16q�6V   �� 5   
   -   5        $��lblvalidName2��5      $��*��6%   ���	#FFFB0000$��20(�6I   $��233,61,-233,-61q�6W   �� 5   
   -   5        $��
cmbSubject��5   B   $
��Left=�6   $��
113,66,0,0q�6.   $ SubjectName��6T    .  $	��Top=�6  $	��120��60  ��6�   �� *SubjectsList+$ PropertyChanged=� 6�   �� *	Subject+$ PropertyChanged=�60  �� 5   
   $
��Left=�6   $��23��6p   $��113,116,0,0q�6|    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6-   �� *Result.Grade+$ PropertyChanged=�6�   �� 5   
   -   5        $��lblGrade��5       $��Grade��6   $
��Left=�60   $��
18,116,0,0q�6K   $	��Top=�6_   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDate��5   0   $
��Left=�6   $��113,167,0,0q�6�   $	��Top=�6�      SelectedDate 6>   �� *Result.Date+$ PropertyChanged=�6�   �� 5   
   -   5        $��btnSave��5      $
��Save��6!   $��20��60   $��70��6<   $
��Left=�6G   $��29,222,0,28q�6�   ��6b   �� *Save+$ PropertyChanged=�6�   �� 5   
   -   5        $��btnClose��5      $��Close��6"   $��20��62   $��70��6>   $��Right=�6I   $��0,222,59,28q�6�   ��6e   �� *Close+$ PropertyChanged=�6�   �� 5   
   -	   5        $��lblDate��5   )   $��Date
��6   $
��Left=�68   $��
18,166,0,0q�6S   $	��Top=�6g   �� 5   
   -
   5        $��lblStudentName��5   '   $��Student Name��6   $
��Left=�6=   $��	16,21,0,0q�6X   $	��Top=�6k   �� 5   
   -   5        $��lblSubjectName��5   1   $��Subject Name
��6   $
��Left=�6G   $��	16,66,0,0q�6b   $	��Top=�6u   5      5      