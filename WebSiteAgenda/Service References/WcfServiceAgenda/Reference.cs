﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18033
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSiteAgenda.WcfServiceAgenda {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceAgenda")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ArtistWS", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceAgenda.Business")]
    [System.SerializableAttribute()]
    public partial class ArtistWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid GiudField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PrenomField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Giud {
            get {
                return this.GiudField;
            }
            set {
                if ((this.GiudField.Equals(value) != true)) {
                    this.GiudField = value;
                    this.RaisePropertyChanged("Giud");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nom {
            get {
                return this.NomField;
            }
            set {
                if ((object.ReferenceEquals(this.NomField, value) != true)) {
                    this.NomField = value;
                    this.RaisePropertyChanged("Nom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Prenom {
            get {
                return this.PrenomField;
            }
            set {
                if ((object.ReferenceEquals(this.PrenomField, value) != true)) {
                    this.PrenomField = value;
                    this.RaisePropertyChanged("Prenom");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EvenementWS", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceAgenda.Business")]
    [System.SerializableAttribute()]
    public partial class EvenementWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebSiteAgenda.WcfServiceAgenda.ArtistWS[] ArtistesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid GuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float TarifField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebSiteAgenda.WcfServiceAgenda.ArtistWS[] Artistes {
            get {
                return this.ArtistesField;
            }
            set {
                if ((object.ReferenceEquals(this.ArtistesField, value) != true)) {
                    this.ArtistesField = value;
                    this.RaisePropertyChanged("Artistes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Guid {
            get {
                return this.GuidField;
            }
            set {
                if ((this.GuidField.Equals(value) != true)) {
                    this.GuidField = value;
                    this.RaisePropertyChanged("Guid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Tarif {
            get {
                return this.TarifField;
            }
            set {
                if ((this.TarifField.Equals(value) != true)) {
                    this.TarifField = value;
                    this.RaisePropertyChanged("Tarif");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Titre {
            get {
                return this.TitreField;
            }
            set {
                if ((object.ReferenceEquals(this.TitreField, value) != true)) {
                    this.TitreField = value;
                    this.RaisePropertyChanged("Titre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LieuWS", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceAgenda.Business")]
    [System.SerializableAttribute()]
    public partial class LieuWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AdresseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid GuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NombrePlacesTotalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> _pourcentageCommissionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Adresse {
            get {
                return this.AdresseField;
            }
            set {
                if ((object.ReferenceEquals(this.AdresseField, value) != true)) {
                    this.AdresseField = value;
                    this.RaisePropertyChanged("Adresse");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Guid {
            get {
                return this.GuidField;
            }
            set {
                if ((this.GuidField.Equals(value) != true)) {
                    this.GuidField = value;
                    this.RaisePropertyChanged("Guid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nom {
            get {
                return this.NomField;
            }
            set {
                if ((object.ReferenceEquals(this.NomField, value) != true)) {
                    this.NomField = value;
                    this.RaisePropertyChanged("Nom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NombrePlacesTotal {
            get {
                return this.NombrePlacesTotalField;
            }
            set {
                if ((this.NombrePlacesTotalField.Equals(value) != true)) {
                    this.NombrePlacesTotalField = value;
                    this.RaisePropertyChanged("NombrePlacesTotal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> _pourcentageCommission {
            get {
                return this._pourcentageCommissionField;
            }
            set {
                if ((this._pourcentageCommissionField.Equals(value) != true)) {
                    this._pourcentageCommissionField = value;
                    this.RaisePropertyChanged("_pourcentageCommission");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlanningElementWS", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceAgenda.Business")]
    [System.SerializableAttribute()]
    public partial class PlanningElementWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateDebutField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DateFinField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid GuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebSiteAgenda.WcfServiceAgenda.EvenementWS MonEvementField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebSiteAgenda.WcfServiceAgenda.LieuWS MonLieuField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NbPlacesReserveesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateDebut {
            get {
                return this.DateDebutField;
            }
            set {
                if ((this.DateDebutField.Equals(value) != true)) {
                    this.DateDebutField = value;
                    this.RaisePropertyChanged("DateDebut");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DateFin {
            get {
                return this.DateFinField;
            }
            set {
                if ((this.DateFinField.Equals(value) != true)) {
                    this.DateFinField = value;
                    this.RaisePropertyChanged("DateFin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Guid {
            get {
                return this.GuidField;
            }
            set {
                if ((this.GuidField.Equals(value) != true)) {
                    this.GuidField = value;
                    this.RaisePropertyChanged("Guid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebSiteAgenda.WcfServiceAgenda.EvenementWS MonEvement {
            get {
                return this.MonEvementField;
            }
            set {
                if ((object.ReferenceEquals(this.MonEvementField, value) != true)) {
                    this.MonEvementField = value;
                    this.RaisePropertyChanged("MonEvement");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebSiteAgenda.WcfServiceAgenda.LieuWS MonLieu {
            get {
                return this.MonLieuField;
            }
            set {
                if ((object.ReferenceEquals(this.MonLieuField, value) != true)) {
                    this.MonLieuField = value;
                    this.RaisePropertyChanged("MonLieu");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NbPlacesReservees {
            get {
                return this.NbPlacesReserveesField;
            }
            set {
                if ((this.NbPlacesReserveesField.Equals(value) != true)) {
                    this.NbPlacesReserveesField = value;
                    this.RaisePropertyChanged("NbPlacesReservees");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UtilisateurWS", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceAgenda.Business")]
    [System.SerializableAttribute()]
    public partial class UtilisateurWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PrenomField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nom {
            get {
                return this.NomField;
            }
            set {
                if ((object.ReferenceEquals(this.NomField, value) != true)) {
                    this.NomField = value;
                    this.RaisePropertyChanged("Nom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Prenom {
            get {
                return this.PrenomField;
            }
            set {
                if ((object.ReferenceEquals(this.PrenomField, value) != true)) {
                    this.PrenomField = value;
                    this.RaisePropertyChanged("Prenom");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfServiceAgenda.IServiceAgenda")]
    public interface IServiceAgenda {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetData", ReplyAction="http://tempuri.org/IServiceAgenda/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetData", ReplyAction="http://tempuri.org/IServiceAgenda/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IServiceAgenda/GetDataUsingDataContractResponse")]
        WebSiteAgenda.WcfServiceAgenda.CompositeType GetDataUsingDataContract(WebSiteAgenda.WcfServiceAgenda.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IServiceAgenda/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.CompositeType> GetDataUsingDataContractAsync(WebSiteAgenda.WcfServiceAgenda.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllArtistes", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllArtistesResponse")]
        WebSiteAgenda.WcfServiceAgenda.ArtistWS[] GetAllArtistes(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllArtistes", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllArtistesResponse")]
        System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.ArtistWS[]> GetAllArtistesAsync(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllEvents", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllEventsResponse")]
        WebSiteAgenda.WcfServiceAgenda.EvenementWS[] GetAllEvents(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllEvents", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllEventsResponse")]
        System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.EvenementWS[]> GetAllEventsAsync(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllEventsByArtiste", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllEventsByArtisteResponse")]
        WebSiteAgenda.WcfServiceAgenda.EvenementWS[] GetAllEventsByArtiste(string login, string passwd, System.Guid guidArtiste);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllEventsByArtiste", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllEventsByArtisteResponse")]
        System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.EvenementWS[]> GetAllEventsByArtisteAsync(string login, string passwd, System.Guid guidArtiste);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllLieux", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllLieuxResponse")]
        WebSiteAgenda.WcfServiceAgenda.LieuWS[] GetAllLieux(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllLieux", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllLieuxResponse")]
        System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.LieuWS[]> GetAllLieuxAsync(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllPlanningElements", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllPlanningElementsResponse")]
        WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[] GetAllPlanningElements(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllPlanningElements", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllPlanningElementsResponse")]
        System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[]> GetAllPlanningElementsAsync(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllPlanningElementsByEvent", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllPlanningElementsByEventResponse")]
        WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[] GetAllPlanningElementsByEvent(string login, string passwd, System.Guid guidEvent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllPlanningElementsByEvent", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllPlanningElementsByEventResponse")]
        System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[]> GetAllPlanningElementsByEventAsync(string login, string passwd, System.Guid guidEvent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllUsers", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllUsersResponse")]
        WebSiteAgenda.WcfServiceAgenda.UtilisateurWS[] GetAllUsers(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/GetAllUsers", ReplyAction="http://tempuri.org/IServiceAgenda/GetAllUsersResponse")]
        System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.UtilisateurWS[]> GetAllUsersAsync(string login, string passwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/CreateUser", ReplyAction="http://tempuri.org/IServiceAgenda/CreateUserResponse")]
        bool CreateUser(string yourLogin, string yourPass, string login, string passwd, string nom, string prenom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAgenda/CreateUser", ReplyAction="http://tempuri.org/IServiceAgenda/CreateUserResponse")]
        System.Threading.Tasks.Task<bool> CreateUserAsync(string yourLogin, string yourPass, string login, string passwd, string nom, string prenom);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceAgendaChannel : WebSiteAgenda.WcfServiceAgenda.IServiceAgenda, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceAgendaClient : System.ServiceModel.ClientBase<WebSiteAgenda.WcfServiceAgenda.IServiceAgenda>, WebSiteAgenda.WcfServiceAgenda.IServiceAgenda {
        
        public ServiceAgendaClient() {
        }
        
        public ServiceAgendaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceAgendaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceAgendaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceAgendaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public WebSiteAgenda.WcfServiceAgenda.CompositeType GetDataUsingDataContract(WebSiteAgenda.WcfServiceAgenda.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.CompositeType> GetDataUsingDataContractAsync(WebSiteAgenda.WcfServiceAgenda.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public WebSiteAgenda.WcfServiceAgenda.ArtistWS[] GetAllArtistes(string login, string passwd) {
            return base.Channel.GetAllArtistes(login, passwd);
        }
        
        public System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.ArtistWS[]> GetAllArtistesAsync(string login, string passwd) {
            return base.Channel.GetAllArtistesAsync(login, passwd);
        }
        
        public WebSiteAgenda.WcfServiceAgenda.EvenementWS[] GetAllEvents(string login, string passwd) {
            return base.Channel.GetAllEvents(login, passwd);
        }
        
        public System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.EvenementWS[]> GetAllEventsAsync(string login, string passwd) {
            return base.Channel.GetAllEventsAsync(login, passwd);
        }
        
        public WebSiteAgenda.WcfServiceAgenda.EvenementWS[] GetAllEventsByArtiste(string login, string passwd, System.Guid guidArtiste) {
            return base.Channel.GetAllEventsByArtiste(login, passwd, guidArtiste);
        }
        
        public System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.EvenementWS[]> GetAllEventsByArtisteAsync(string login, string passwd, System.Guid guidArtiste) {
            return base.Channel.GetAllEventsByArtisteAsync(login, passwd, guidArtiste);
        }
        
        public WebSiteAgenda.WcfServiceAgenda.LieuWS[] GetAllLieux(string login, string passwd) {
            return base.Channel.GetAllLieux(login, passwd);
        }
        
        public System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.LieuWS[]> GetAllLieuxAsync(string login, string passwd) {
            return base.Channel.GetAllLieuxAsync(login, passwd);
        }
        
        public WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[] GetAllPlanningElements(string login, string passwd) {
            return base.Channel.GetAllPlanningElements(login, passwd);
        }
        
        public System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[]> GetAllPlanningElementsAsync(string login, string passwd) {
            return base.Channel.GetAllPlanningElementsAsync(login, passwd);
        }
        
        public WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[] GetAllPlanningElementsByEvent(string login, string passwd, System.Guid guidEvent) {
            return base.Channel.GetAllPlanningElementsByEvent(login, passwd, guidEvent);
        }
        
        public System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[]> GetAllPlanningElementsByEventAsync(string login, string passwd, System.Guid guidEvent) {
            return base.Channel.GetAllPlanningElementsByEventAsync(login, passwd, guidEvent);
        }
        
        public WebSiteAgenda.WcfServiceAgenda.UtilisateurWS[] GetAllUsers(string login, string passwd) {
            return base.Channel.GetAllUsers(login, passwd);
        }
        
        public System.Threading.Tasks.Task<WebSiteAgenda.WcfServiceAgenda.UtilisateurWS[]> GetAllUsersAsync(string login, string passwd) {
            return base.Channel.GetAllUsersAsync(login, passwd);
        }
        
        public bool CreateUser(string yourLogin, string yourPass, string login, string passwd, string nom, string prenom) {
            return base.Channel.CreateUser(yourLogin, yourPass, login, passwd, nom, prenom);
        }
        
        public System.Threading.Tasks.Task<bool> CreateUserAsync(string yourLogin, string yourPass, string login, string passwd, string nom, string prenom) {
            return base.Channel.CreateUserAsync(yourLogin, yourPass, login, passwd, nom, prenom);
        }
    }
}
