﻿#pragma checksum "..\..\..\FrmExam.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "689679D8CE3A0C276C86D257F88D0CE88B7433BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectPRN;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ProjectPRN {
    
    
    /// <summary>
    /// FrmExam
    /// </summary>
    public partial class FrmExam : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbQuestions;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgExam;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbRandom;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbManual;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel randomPanel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNameExam;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRandomCount;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel manualPanel;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNameExam1;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtID;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\FrmExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectPRN;component/frmexam.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\FrmExam.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbQuestions = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.dgExam = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\..\FrmExam.xaml"
            this.dgExam.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgExam_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 18 "..\..\..\FrmExam.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rbRandom = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\..\FrmExam.xaml"
            this.rbRandom.Checked += new System.Windows.RoutedEventHandler(this.SelectionMethod_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rbManual = ((System.Windows.Controls.RadioButton)(target));
            
            #line 22 "..\..\..\FrmExam.xaml"
            this.rbManual.Checked += new System.Windows.RoutedEventHandler(this.SelectionMethod_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.randomPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.txtNameExam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtRandomCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 30 "..\..\..\FrmExam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateRandomExam_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.manualPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.txtNameExam1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            
            #line 37 "..\..\..\FrmExam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateManualExam_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 40 "..\..\..\FrmExam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.txtID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            
            #line 42 "..\..\..\FrmExam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 43 "..\..\..\FrmExam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 17:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

