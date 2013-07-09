//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by Web Services Description Language Utility
//Mono Framework v4.0.30319.296
//


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/")]
public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback RegisterOperationCompleted;
    
    private System.Threading.SendOrPostCallback LogOutOperationCompleted;
    
    private System.Threading.SendOrPostCallback LogInOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetIPOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetMovementOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetListMovementOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetListSkillOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetListIDSkillOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetSkilDataOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetListPetOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetMedalOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetAllPetDetailOperationCompleted;
    
    private System.Threading.SendOrPostCallback CreateNewPetOperationCompleted;
    
    /// <remarks/>
    public Service1() {
        this.Url = "http://localhost:56597/Service1.asmx";
    }
    
    /// <remarks/>
    public event RegisterCompletedEventHandler RegisterCompleted;
    
    /// <remarks/>
    public event LogOutCompletedEventHandler LogOutCompleted;
    
    /// <remarks/>
    public event LogInCompletedEventHandler LogInCompleted;
    
    /// <remarks/>
    public event GetIPCompletedEventHandler GetIPCompleted;
    
    /// <remarks/>
    public event GetMovementCompletedEventHandler GetMovementCompleted;
    
    /// <remarks/>
    public event GetListMovementCompletedEventHandler GetListMovementCompleted;
    
    /// <remarks/>
    public event GetListSkillCompletedEventHandler GetListSkillCompleted;
    
    /// <remarks/>
    public event GetListIDSkillCompletedEventHandler GetListIDSkillCompleted;
    
    /// <remarks/>
    public event GetSkilDataCompletedEventHandler GetSkilDataCompleted;
    
    /// <remarks/>
    public event GetListPetCompletedEventHandler GetListPetCompleted;
    
    /// <remarks/>
    public event GetMedalCompletedEventHandler GetMedalCompleted;
    
    /// <remarks/>
    public event GetAllPetDetailCompletedEventHandler GetAllPetDetailCompleted;
    
    /// <remarks/>
    public event CreateNewPetCompletedEventHandler CreateNewPetCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Register", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public int Register(string username, string pw, string email, string image) {
        object[] results = this.Invoke("Register", new object[] {
                    username,
                    pw,
                    email,
                    image});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void RegisterAsync(string username, string pw, string email, string image) {
        this.RegisterAsync(username, pw, email, image, null);
    }
    
    /// <remarks/>
    public void RegisterAsync(string username, string pw, string email, string image, object userState) {
        if ((this.RegisterOperationCompleted == null)) {
            this.RegisterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterOperationCompleted);
        }
        this.InvokeAsync("Register", new object[] {
                    username,
                    pw,
                    email,
                    image}, this.RegisterOperationCompleted, userState);
    }
    
    private void OnRegisterOperationCompleted(object arg) {
        if ((this.RegisterCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.RegisterCompleted(this, new RegisterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LogOut", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void LogOut(string id) {
        this.Invoke("LogOut", new object[] {
                    id});
    }
    
    /// <remarks/>
    public void LogOutAsync(string id) {
        this.LogOutAsync(id, null);
    }
    
    /// <remarks/>
    public void LogOutAsync(string id, object userState) {
        if ((this.LogOutOperationCompleted == null)) {
            this.LogOutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogOutOperationCompleted);
        }
        this.InvokeAsync("LogOut", new object[] {
                    id}, this.LogOutOperationCompleted, userState);
    }
    
    private void OnLogOutOperationCompleted(object arg) {
        if ((this.LogOutCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.LogOutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LogIn", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string LogIn(string username, string pass, string ip) {
        object[] results = this.Invoke("LogIn", new object[] {
                    username,
                    pass,
                    ip});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void LogInAsync(string username, string pass, string ip) {
        this.LogInAsync(username, pass, ip, null);
    }
    
    /// <remarks/>
    public void LogInAsync(string username, string pass, string ip, object userState) {
        if ((this.LogInOperationCompleted == null)) {
            this.LogInOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogInOperationCompleted);
        }
        this.InvokeAsync("LogIn", new object[] {
                    username,
                    pass,
                    ip}, this.LogInOperationCompleted, userState);
    }
    
    private void OnLogInOperationCompleted(object arg) {
        if ((this.LogInCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.LogInCompleted(this, new LogInCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetIP", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string GetIP(string getipname) {
        object[] results = this.Invoke("GetIP", new object[] {
                    getipname});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void GetIPAsync(string getipname) {
        this.GetIPAsync(getipname, null);
    }
    
    /// <remarks/>
    public void GetIPAsync(string getipname, object userState) {
        if ((this.GetIPOperationCompleted == null)) {
            this.GetIPOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetIPOperationCompleted);
        }
        this.InvokeAsync("GetIP", new object[] {
                    getipname}, this.GetIPOperationCompleted, userState);
    }
    
    private void OnGetIPOperationCompleted(object arg) {
        if ((this.GetIPCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetIPCompleted(this, new GetIPCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetMovement", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string GetMovement(int id) {
        object[] results = this.Invoke("GetMovement", new object[] {
                    id});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void GetMovementAsync(int id) {
        this.GetMovementAsync(id, null);
    }
    
    /// <remarks/>
    public void GetMovementAsync(int id, object userState) {
        if ((this.GetMovementOperationCompleted == null)) {
            this.GetMovementOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMovementOperationCompleted);
        }
        this.InvokeAsync("GetMovement", new object[] {
                    id}, this.GetMovementOperationCompleted, userState);
    }
    
    private void OnGetMovementOperationCompleted(object arg) {
        if ((this.GetMovementCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetMovementCompleted(this, new GetMovementCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetListMovement", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public int[] GetListMovement(int skillID) {
        object[] results = this.Invoke("GetListMovement", new object[] {
                    skillID});
        return ((int[])(results[0]));
    }
    
    /// <remarks/>
    public void GetListMovementAsync(int skillID) {
        this.GetListMovementAsync(skillID, null);
    }
    
    /// <remarks/>
    public void GetListMovementAsync(int skillID, object userState) {
        if ((this.GetListMovementOperationCompleted == null)) {
            this.GetListMovementOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListMovementOperationCompleted);
        }
        this.InvokeAsync("GetListMovement", new object[] {
                    skillID}, this.GetListMovementOperationCompleted, userState);
    }
    
    private void OnGetListMovementOperationCompleted(object arg) {
        if ((this.GetListMovementCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetListMovementCompleted(this, new GetListMovementCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetListSkill", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string GetListSkill(int petID) {
        object[] results = this.Invoke("GetListSkill", new object[] {
                    petID});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void GetListSkillAsync(int petID) {
        this.GetListSkillAsync(petID, null);
    }
    
    /// <remarks/>
    public void GetListSkillAsync(int petID, object userState) {
        if ((this.GetListSkillOperationCompleted == null)) {
            this.GetListSkillOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListSkillOperationCompleted);
        }
        this.InvokeAsync("GetListSkill", new object[] {
                    petID}, this.GetListSkillOperationCompleted, userState);
    }
    
    private void OnGetListSkillOperationCompleted(object arg) {
        if ((this.GetListSkillCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetListSkillCompleted(this, new GetListSkillCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetListIDSkill", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public int[] GetListIDSkill(int petID) {
        object[] results = this.Invoke("GetListIDSkill", new object[] {
                    petID});
        return ((int[])(results[0]));
    }
    
    /// <remarks/>
    public void GetListIDSkillAsync(int petID) {
        this.GetListIDSkillAsync(petID, null);
    }
    
    /// <remarks/>
    public void GetListIDSkillAsync(int petID, object userState) {
        if ((this.GetListIDSkillOperationCompleted == null)) {
            this.GetListIDSkillOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListIDSkillOperationCompleted);
        }
        this.InvokeAsync("GetListIDSkill", new object[] {
                    petID}, this.GetListIDSkillOperationCompleted, userState);
    }
    
    private void OnGetListIDSkillOperationCompleted(object arg) {
        if ((this.GetListIDSkillCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetListIDSkillCompleted(this, new GetListIDSkillCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSkilData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string GetSkilData(int skillID) {
        object[] results = this.Invoke("GetSkilData", new object[] {
                    skillID});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void GetSkilDataAsync(int skillID) {
        this.GetSkilDataAsync(skillID, null);
    }
    
    /// <remarks/>
    public void GetSkilDataAsync(int skillID, object userState) {
        if ((this.GetSkilDataOperationCompleted == null)) {
            this.GetSkilDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSkilDataOperationCompleted);
        }
        this.InvokeAsync("GetSkilData", new object[] {
                    skillID}, this.GetSkilDataOperationCompleted, userState);
    }
    
    private void OnGetSkilDataOperationCompleted(object arg) {
        if ((this.GetSkilDataCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetSkilDataCompleted(this, new GetSkilDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetListPet", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string GetListPet(int playerID) {
        object[] results = this.Invoke("GetListPet", new object[] {
                    playerID});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void GetListPetAsync(int playerID) {
        this.GetListPetAsync(playerID, null);
    }
    
    /// <remarks/>
    public void GetListPetAsync(int playerID, object userState) {
        if ((this.GetListPetOperationCompleted == null)) {
            this.GetListPetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListPetOperationCompleted);
        }
        this.InvokeAsync("GetListPet", new object[] {
                    playerID}, this.GetListPetOperationCompleted, userState);
    }
    
    private void OnGetListPetOperationCompleted(object arg) {
        if ((this.GetListPetCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetListPetCompleted(this, new GetListPetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetMedal", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string GetMedal(int id) {
        object[] results = this.Invoke("GetMedal", new object[] {
                    id});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void GetMedalAsync(int id) {
        this.GetMedalAsync(id, null);
    }
    
    /// <remarks/>
    public void GetMedalAsync(int id, object userState) {
        if ((this.GetMedalOperationCompleted == null)) {
            this.GetMedalOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMedalOperationCompleted);
        }
        this.InvokeAsync("GetMedal", new object[] {
                    id}, this.GetMedalOperationCompleted, userState);
    }
    
    private void OnGetMedalOperationCompleted(object arg) {
        if ((this.GetMedalCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetMedalCompleted(this, new GetMedalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllPetDetail", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string GetAllPetDetail() {
        object[] results = this.Invoke("GetAllPetDetail", new object[0]);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void GetAllPetDetailAsync() {
        this.GetAllPetDetailAsync(null);
    }
    
    /// <remarks/>
    public void GetAllPetDetailAsync(object userState) {
        if ((this.GetAllPetDetailOperationCompleted == null)) {
            this.GetAllPetDetailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllPetDetailOperationCompleted);
        }
        this.InvokeAsync("GetAllPetDetail", new object[0], this.GetAllPetDetailOperationCompleted, userState);
    }
    
    private void OnGetAllPetDetailOperationCompleted(object arg) {
        if ((this.GetAllPetDetailCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetAllPetDetailCompleted(this, new GetAllPetDetailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CreateNewPet", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void CreateNewPet(string fStr) {
        this.Invoke("CreateNewPet", new object[] {
                    fStr});
    }
    
    /// <remarks/>
    public void CreateNewPetAsync(string fStr) {
        this.CreateNewPetAsync(fStr, null);
    }
    
    /// <remarks/>
    public void CreateNewPetAsync(string fStr, object userState) {
        if ((this.CreateNewPetOperationCompleted == null)) {
            this.CreateNewPetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateNewPetOperationCompleted);
        }
        this.InvokeAsync("CreateNewPet", new object[] {
                    fStr}, this.CreateNewPetOperationCompleted, userState);
    }
    
    private void OnCreateNewPetOperationCompleted(object arg) {
        if ((this.CreateNewPetCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.CreateNewPetCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void RegisterCompletedEventHandler(object sender, RegisterCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class RegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal RegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public int Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void LogOutCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void LogInCompletedEventHandler(object sender, LogInCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class LogInCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal LogInCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetIPCompletedEventHandler(object sender, GetIPCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetIPCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetIPCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetMovementCompletedEventHandler(object sender, GetMovementCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetMovementCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetMovementCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetListMovementCompletedEventHandler(object sender, GetListMovementCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetListMovementCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetListMovementCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public int[] Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((int[])(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetListSkillCompletedEventHandler(object sender, GetListSkillCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetListSkillCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetListSkillCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetListIDSkillCompletedEventHandler(object sender, GetListIDSkillCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetListIDSkillCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetListIDSkillCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public int[] Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((int[])(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetSkilDataCompletedEventHandler(object sender, GetSkilDataCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetSkilDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetSkilDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetListPetCompletedEventHandler(object sender, GetListPetCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetListPetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetListPetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetMedalCompletedEventHandler(object sender, GetMedalCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetMedalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetMedalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetAllPetDetailCompletedEventHandler(object sender, GetAllPetDetailCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetAllPetDetailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetAllPetDetailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void CreateNewPetCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
