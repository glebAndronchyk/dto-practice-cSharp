using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace lb4.Views
{
    public partial class ListView : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ListView), new PropertyMetadata(null));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty OnEditProperty =
            DependencyProperty.Register("OnEdit", typeof(RoutedEventHandler), typeof(ListView));

        public RoutedEventHandler OnEdit
        {
            get { return (RoutedEventHandler)GetValue(OnEditProperty); }
            set { SetValue(OnEditProperty, value); }
        }

        public static readonly DependencyProperty OnRemoveProperty =
            DependencyProperty.Register("OnRemove", typeof(RoutedEventHandler), typeof(ListView));

        public RoutedEventHandler OnRemove
        {
            get { return (RoutedEventHandler)GetValue(OnRemoveProperty); }
            set { SetValue(OnRemoveProperty, value); }
        }

        public static readonly DependencyProperty OnAddNewProperty =
            DependencyProperty.Register("OnAddNew", typeof(RoutedEventHandler), typeof(ListView));

        public RoutedEventHandler OnAddNew
        {
            get { return (RoutedEventHandler)GetValue(OnAddNewProperty); }
            set { SetValue(OnAddNewProperty, value); }
        }

        public static readonly DependencyProperty AddNewTextProperty =
            DependencyProperty.Register("AddNewText", typeof(string), typeof(ListView));

        public string AddNewText
        {
            get { return (string)GetValue(AddNewTextProperty); }
            set { SetValue(AddNewTextProperty, value); }
        }

        public ListBox ListBox => listbox;

        public ListView()
        {
            InitializeComponent();
        }

        private void OnEditClick(object sender, RoutedEventArgs e)
        {
            OnEdit?.Invoke(this, e);
        }

        private void OnRemoveClick(object sender, RoutedEventArgs e)
        {
            OnRemove?.Invoke(this, e);
        }

        private void OnAddNewClick(object sender, RoutedEventArgs e)
        {
            OnAddNew?.Invoke(this, e);
        }
    }
}