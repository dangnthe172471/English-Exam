﻿#pragma checksum "..\..\..\FrmDoExam.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DBCC42972A0AFF26B9D9C2CC767D05DEE20CF572"
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
    /// FrmDoExam
    /// </summary>
    public partial class FrmDoExam : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\FrmDoExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimerTextBlock;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\FrmDoExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QuestionNumberTextBlock;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\FrmDoExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QuestionPromptTextBlock;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\FrmDoExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QuestionContentTextBlock;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\FrmDoExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Answer1RadioButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\FrmDoExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Answer2RadioButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\FrmDoExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Answer3RadioButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\FrmDoExam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Answer4RadioButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectPRN;component/frmdoexam.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\FrmDoExam.xaml"
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
            this.TimerTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.QuestionNumberTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.QuestionPromptTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.QuestionContentTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Answer1RadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.Answer2RadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.Answer3RadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.Answer4RadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            
            #line 31 "..\..\..\FrmDoExam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PreviousButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 32 "..\..\..\FrmDoExam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 33 "..\..\..\FrmDoExam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SubmitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

