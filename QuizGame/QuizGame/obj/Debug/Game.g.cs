﻿#pragma checksum "..\..\Game.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "94C6C5C922FD921819297DE214BB97CECEF44329DA45DB9635DBBBD306E042CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuizGame;
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


namespace QuizGame {
    
    
    /// <summary>
    /// Game
    /// </summary>
    public partial class Game : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label kerdesekszama;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ido_label;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label kerdes_kozti_ido;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressbar_kiiras;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock kerdes_txt;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button valasz_elsoeleme;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button valasz_masodikeleme;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button valasz_harmadikeleme;
        
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
            System.Uri resourceLocater = new System.Uri("/QuizGame;component/game.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Game.xaml"
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
            this.kerdesekszama = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.ido_label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.kerdes_kozti_ido = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.progressbar_kiiras = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 5:
            this.kerdes_txt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.valasz_elsoeleme = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\Game.xaml"
            this.valasz_elsoeleme.Click += new System.Windows.RoutedEventHandler(this.helyes_valasz);
            
            #line default
            #line hidden
            return;
            case 7:
            this.valasz_masodikeleme = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Game.xaml"
            this.valasz_masodikeleme.Click += new System.Windows.RoutedEventHandler(this.rossz1_valasz);
            
            #line default
            #line hidden
            return;
            case 8:
            this.valasz_harmadikeleme = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Game.xaml"
            this.valasz_harmadikeleme.Click += new System.Windows.RoutedEventHandler(this.rossz2_valasz);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

