 

/**
* Service Proxy for CpProxySchemasUpnpOrgScheduledRecording2
* @module Zapp
* @class ScheduledRecording
*/
	
var CpProxySchemasUpnpOrgScheduledRecording2 = function(udn){	

	this.url = window.location.protocol + "//" + window.location.host + "/" + udn + "/upnp.org-ScheduledRecording-2/control";  // upnp control url
	this.domain = "schemas-upnp-org";
	this.type = "ScheduledRecording";
	this.version = "2";
	this.serviceName = "upnp.org-ScheduledRecording-2";
	this.subscriptionId = "";  // Subscription identifier unique to each Subscription Manager 
	this.udn = udn;   // device name
	
	// Collection of service properties
	this.serviceProperties = {};
	this.serviceProperties["LastChange"] = new Zapp.ServiceProperty("LastChange","string");
}



/**
* Subscribes the service to the subscription manager to listen for property change events
* @method Subscribe
* @param {Function} serviceAddedFunction The function that executes once the subscription is successful
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.subscribe = function (serviceAddedFunction) {
    Zapp.SubscriptionManager.addService(this,serviceAddedFunction);
}


/**
* Unsubscribes the service from the subscription manager to stop listening for property change events
* @method Unsubscribe
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.unsubscribe = function () {
    Zapp.SubscriptionManager.removeService(this.subscriptionId);
}


	

/**
* Adds a listener to handle "LastChange" property change events
* @method LastChange_Changed
* @param {Function} stateChangedFunction The handler for state changes
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.LastChange_Changed = function (stateChangedFunction) {
    this.serviceProperties.LastChange.addListener(function (state) 
	{ 
		stateChangedFunction(Zapp.SoapRequest.readStringParameter(state)); 
	});
}


/**
* A service action to GetSortCapabilities
* @method GetSortCapabilities
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.GetSortCapabilities = function(successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("GetSortCapabilities", this.url, this.formattedDomain, this.type, this.version);		
    request.send(function(result){
		result["SortCaps"] = Zapp.SoapRequest.readStringParameter(result["SortCaps"]);	
		result["SortLevelCap"] = Zapp.SoapRequest.readIntParameter(result["SortLevelCap"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to GetPropertyList
* @method GetPropertyList
* @param {String} DataTypeID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.GetPropertyList = function(DataTypeID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("GetPropertyList", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("DataTypeID", DataTypeID);
    request.send(function(result){
		result["PropertyList"] = Zapp.SoapRequest.readStringParameter(result["PropertyList"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to GetAllowedValues
* @method GetAllowedValues
* @param {String} DataTypeID An action parameter
* @param {String} Filter An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.GetAllowedValues = function(DataTypeID, Filter, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("GetAllowedValues", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("DataTypeID", DataTypeID);
    request.writeStringParameter("Filter", Filter);
    request.send(function(result){
		result["PropertyInfo"] = Zapp.SoapRequest.readStringParameter(result["PropertyInfo"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to GetStateUpdateID
* @method GetStateUpdateID
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.GetStateUpdateID = function(successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("GetStateUpdateID", this.url, this.formattedDomain, this.type, this.version);		
    request.send(function(result){
		result["Id"] = Zapp.SoapRequest.readIntParameter(result["Id"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to BrowseRecordSchedules
* @method BrowseRecordSchedules
* @param {String} Filter An action parameter
* @param {Int} StartingIndex An action parameter
* @param {Int} RequestedCount An action parameter
* @param {String} SortCriteria An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.BrowseRecordSchedules = function(Filter, StartingIndex, RequestedCount, SortCriteria, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("BrowseRecordSchedules", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("Filter", Filter);
    request.writeIntParameter("StartingIndex", StartingIndex);
    request.writeIntParameter("RequestedCount", RequestedCount);
    request.writeStringParameter("SortCriteria", SortCriteria);
    request.send(function(result){
		result["Result"] = Zapp.SoapRequest.readStringParameter(result["Result"]);	
		result["NumberReturned"] = Zapp.SoapRequest.readIntParameter(result["NumberReturned"]);	
		result["TotalMatches"] = Zapp.SoapRequest.readIntParameter(result["TotalMatches"]);	
		result["UpdateID"] = Zapp.SoapRequest.readIntParameter(result["UpdateID"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to BrowseRecordTasks
* @method BrowseRecordTasks
* @param {String} RecordScheduleID An action parameter
* @param {String} Filter An action parameter
* @param {Int} StartingIndex An action parameter
* @param {Int} RequestedCount An action parameter
* @param {String} SortCriteria An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.BrowseRecordTasks = function(RecordScheduleID, Filter, StartingIndex, RequestedCount, SortCriteria, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("BrowseRecordTasks", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordScheduleID", RecordScheduleID);
    request.writeStringParameter("Filter", Filter);
    request.writeIntParameter("StartingIndex", StartingIndex);
    request.writeIntParameter("RequestedCount", RequestedCount);
    request.writeStringParameter("SortCriteria", SortCriteria);
    request.send(function(result){
		result["Result"] = Zapp.SoapRequest.readStringParameter(result["Result"]);	
		result["NumberReturned"] = Zapp.SoapRequest.readIntParameter(result["NumberReturned"]);	
		result["TotalMatches"] = Zapp.SoapRequest.readIntParameter(result["TotalMatches"]);	
		result["UpdateID"] = Zapp.SoapRequest.readIntParameter(result["UpdateID"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to CreateRecordSchedule
* @method CreateRecordSchedule
* @param {String} Elements An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.CreateRecordSchedule = function(Elements, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("CreateRecordSchedule", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("Elements", Elements);
    request.send(function(result){
		result["RecordScheduleID"] = Zapp.SoapRequest.readStringParameter(result["RecordScheduleID"]);	
		result["Result"] = Zapp.SoapRequest.readStringParameter(result["Result"]);	
		result["UpdateID"] = Zapp.SoapRequest.readIntParameter(result["UpdateID"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to DeleteRecordSchedule
* @method DeleteRecordSchedule
* @param {String} RecordScheduleID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.DeleteRecordSchedule = function(RecordScheduleID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("DeleteRecordSchedule", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordScheduleID", RecordScheduleID);
    request.send(function(result){
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to GetRecordSchedule
* @method GetRecordSchedule
* @param {String} RecordScheduleID An action parameter
* @param {String} Filter An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.GetRecordSchedule = function(RecordScheduleID, Filter, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("GetRecordSchedule", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordScheduleID", RecordScheduleID);
    request.writeStringParameter("Filter", Filter);
    request.send(function(result){
		result["Result"] = Zapp.SoapRequest.readStringParameter(result["Result"]);	
		result["UpdateID"] = Zapp.SoapRequest.readIntParameter(result["UpdateID"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to EnableRecordSchedule
* @method EnableRecordSchedule
* @param {String} RecordScheduleID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.EnableRecordSchedule = function(RecordScheduleID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("EnableRecordSchedule", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordScheduleID", RecordScheduleID);
    request.send(function(result){
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to DisableRecordSchedule
* @method DisableRecordSchedule
* @param {String} RecordScheduleID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.DisableRecordSchedule = function(RecordScheduleID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("DisableRecordSchedule", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordScheduleID", RecordScheduleID);
    request.send(function(result){
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to DeleteRecordTask
* @method DeleteRecordTask
* @param {String} RecordTaskID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.DeleteRecordTask = function(RecordTaskID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("DeleteRecordTask", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordTaskID", RecordTaskID);
    request.send(function(result){
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to GetRecordTask
* @method GetRecordTask
* @param {String} RecordTaskID An action parameter
* @param {String} Filter An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.GetRecordTask = function(RecordTaskID, Filter, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("GetRecordTask", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordTaskID", RecordTaskID);
    request.writeStringParameter("Filter", Filter);
    request.send(function(result){
		result["Result"] = Zapp.SoapRequest.readStringParameter(result["Result"]);	
		result["UpdateID"] = Zapp.SoapRequest.readIntParameter(result["UpdateID"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to EnableRecordTask
* @method EnableRecordTask
* @param {String} RecordTaskID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.EnableRecordTask = function(RecordTaskID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("EnableRecordTask", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordTaskID", RecordTaskID);
    request.send(function(result){
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to DisableRecordTask
* @method DisableRecordTask
* @param {String} RecordTaskID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.DisableRecordTask = function(RecordTaskID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("DisableRecordTask", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordTaskID", RecordTaskID);
    request.send(function(result){
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to ResetRecordTask
* @method ResetRecordTask
* @param {String} RecordTaskID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.ResetRecordTask = function(RecordTaskID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("ResetRecordTask", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordTaskID", RecordTaskID);
    request.send(function(result){
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to GetRecordScheduleConflicts
* @method GetRecordScheduleConflicts
* @param {String} RecordScheduleID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.GetRecordScheduleConflicts = function(RecordScheduleID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("GetRecordScheduleConflicts", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordScheduleID", RecordScheduleID);
    request.send(function(result){
		result["RecordScheduleConflictIDList"] = Zapp.SoapRequest.readStringParameter(result["RecordScheduleConflictIDList"]);	
		result["UpdateID"] = Zapp.SoapRequest.readIntParameter(result["UpdateID"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}


/**
* A service action to GetRecordTaskConflicts
* @method GetRecordTaskConflicts
* @param {String} RecordTaskID An action parameter
* @param {Function} successFunction The function that is executed when the action has completed successfully
* @param {Function} errorFunction The function that is executed when the action has cause an error
*/
CpProxySchemasUpnpOrgScheduledRecording2.prototype.GetRecordTaskConflicts = function(RecordTaskID, successFunction, errorFunction){	
	var request = new Zapp.SoapRequest("GetRecordTaskConflicts", this.url, this.formattedDomain, this.type, this.version);		
    request.writeStringParameter("RecordTaskID", RecordTaskID);
    request.send(function(result){
		result["RecordTaskConflictIDList"] = Zapp.SoapRequest.readStringParameter(result["RecordTaskConflictIDList"]);	
		result["UpdateID"] = Zapp.SoapRequest.readIntParameter(result["UpdateID"]);	
	
		if (successFunction){
			successFunction(result);
		}
	}, function(message, transport) {
		if (errorFunction) {errorFunction(message, transport);}
	});
}



