   M S B A M L   `   `   `  ����E  ACRUD-Lista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CRUD_Lista
CRUD_Lista  5   	       CRUD_Lista.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:CRUD_Lista     5   	     � Title$
  Crud��5   	   $	��400��6   $	��800��6#   .��5	      � $��10q�6   .+�5   
   �� $
��Left=�6(   $��
14,110,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��129��6�   $��24��6�   ��6   �� *nome+6�   �� 5   
   $��	Adicionar��6/   $��14,139,646,182q�6C   ��6   �� *	adicionar+6C   �� 5   
   -   5        $��b2��5   =   $��Apagar��6,   $��14,187,646,136q�6G   ��6   �� *apagar+6G   �� 5   
   $��Editar��6,   $
��Left=�6=   $��
14,233,0,0q�6X   $	��Top=�6l   $��28��6�   $	��120��6�   ��6   �� *editar+6�   �� 5   
   -   5        $��	ListView1��5   p   $��148,73,438,125q�6�   ��6   �� *lista+ �� SelectedIndex 61   �� *index+ �� SelectedItem 6Q   �� *value+ �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   $��Digitar Nome:��6   $
��Left=�6(   $��	14,80,0,0q�6C   $	��Top=�6V    J� RenderTransformOrigin$ 0.528,0.565&�6n   $	��114��6�   $��30��6�   �� 5   
   $��Adcionar��6   $
��Left=�6$   $��436,207,0,0q�6?   $	��Top=�6T   �� 5   
   $��Apagar��6   $
��Left=�6>   $��518,207,0,0q�6Y   $	��Top=�6n   ��6"   �� *	apagar2+6n   �� 5   
   $��Button��6   $
��Left=�6"   $��583,207,0,0q�6=   $	��Top=�6R   �� 5   
   $
��Left=�6   $��479,263,0,0q�6-   $
 Wrap=�6B   $��TextBox��6V   $	��Top=�6e   $	��120��6}   &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns$ False��6a      
IsReadOnly$
 True��6}   $��435,52,100,172q�6�   ��6   �� *
pokemons+ 64   �� *PokemonSelecionado+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+  5      $
	 Nome��6%   
 63   �� *Nome+  5      $	 Apelido��6%   
 66   �� *	Apelido+  5       $	 Nível��6%   
 64   �� *Nivel+  5!      $
	 Tipo��6%   
 63   �� *Tipo+5#      5$      5&      