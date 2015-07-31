var ViewModel = function () {
    var self = this;
    self.devices = ko.observableArray();
    self.usuarios = ko.observableArray();
    self.sensores = ko.observableArray();
    self.medidas = ko.observableArray();
    self.error = ko.observable();

    var devicesUri = '/api/devices/';    
    var medidasUri = '/api/medidas/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllDevices() {
        ajaxHelper(devicesUri, 'GET').done(function (data) {
            self.devices(data);
        });
    }

    function getAllMedidas() {
        ajaxHelper(devicesUri, 'GET').done(function (data) {
            self.devices(data);
        });
    }


    // Fetch the initial data.
    getAllMedidas();
};

ko.applyBindings(new ViewModel());