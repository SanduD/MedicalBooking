﻿#pragma checksum "..\..\RegisterWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6AC78589C2A8EC6989A7036E3AF7A7A06E0EB5AC3A0267F80AB4CB190BB23A6E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using MedBookDRS;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MedBookDRS {
    
    
    /// <summary>
    /// RegisterWindow
    /// </summary>
    public partial class RegisterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 140 "..\..\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBox_Nume;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBox_Prenume;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RdBtn_Barbat;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RdBtn_Femeie;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DP_DataNastere;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBox_NrTelefon;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBox_Email;
        
        #line default
        #line hidden
        
        
        #line 226 "..\..\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PassowordBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MedBookDRS;component/registerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegisterWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 54 "..\..\RegisterWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Btn);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 66 "..\..\RegisterWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 84 "..\..\RegisterWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseBtn_Reg);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 89 "..\..\RegisterWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MiniminizeBtn_Reg);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TxtBox_Nume = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TxtBox_Prenume = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.RdBtn_Barbat = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.RdBtn_Femeie = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.DP_DataNastere = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.TxtBox_NrTelefon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.TxtBox_Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.PassowordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 13:
            
            #line 247 "..\..\RegisterWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SignUP_Btn);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

