﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WP_TT
{
    public sealed partial class AnalogWatchControl : UserControl
    {
        DependencyProperty DateTimeProperty = DependencyProperty.Register("DateTime", typeof(DateTime), typeof(AnalogWatchControl), new PropertyMetadata(DateTime.Now));

        public DateTime DateTime
        {
            get
            {
                return (DateTime)GetValue(DateTimeProperty);
            }
            set
            {
                SetValue(DateTimeProperty, value);
            }
        }

        public AnalogWatchControl()
        {
            this.InitializeComponent();
        }
    }

    public class AnalogWatchConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int param = int.Parse(parameter.ToString());

            DateTime date = (DateTime)value;

            switch (param)
            {
                case 0: return date.Second * 6;
                case 1: return date.Minute * 6;
                case 2: return (date.Hour * 30) + (date.Minute * 0.5);
                default: return 0;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
