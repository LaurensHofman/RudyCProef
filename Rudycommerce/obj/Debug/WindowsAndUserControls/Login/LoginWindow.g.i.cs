﻿#pragma checksum "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0D38321ED68A7C0227E4E71E94DFC4C83A082245"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Rudycommerce;
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


namespace Rudycommerce {
    
    
    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbPreferNL;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbPreferEN;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsername;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwdPassword;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPasswordVisible;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowHidePwd;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewUser;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLazy;
        
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
            System.Uri resourceLocater = new System.Uri("/Rudycommerce;component/windowsandusercontrols/login/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
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
            
            #line 9 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            ((Rudycommerce.LoginWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rbPreferNL = ((System.Windows.Controls.RadioButton)(target));
            
            #line 55 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            this.rbPreferNL.Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rbPreferEN = ((System.Windows.Controls.RadioButton)(target));
            
            #line 56 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            this.rbPreferEN.Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.pwdPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 81 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            this.pwdPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.pwdPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtPasswordVisible = ((System.Windows.Controls.TextBox)(target));
            
            #line 83 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            this.txtPasswordVisible.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtPasswordVisible_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnShowHidePwd = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            this.btnShowHidePwd.Click += new System.Windows.RoutedEventHandler(this.btnShowHidePwd_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnNewUser = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            this.btnNewUser.Click += new System.Windows.RoutedEventHandler(this.btnNewUser_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnLazy = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\..\WindowsAndUserControls\Login\LoginWindow.xaml"
            this.btnLazy.Click += new System.Windows.RoutedEventHandler(this.btnLazy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
