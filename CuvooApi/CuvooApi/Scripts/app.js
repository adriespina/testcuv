var ViewModel = function () {
    var self = this;
    self.devices = ko.observableArray();
    self.usuarios = ko.observableArray();
    self.medidas = ko.observableArray();
    self.error = ko.observable();
    self.datos = ko.observable();

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

    function showPosition(position) {
       
    }

    self.getMedidasDispositivo = function (item) {
        ajaxHelper(medidasUri + item.ID, 'GET').done(function (data) {
            self.medidas(data);
            self.datos(true);           
        });
    }

        function getAllMedidas() {
            ajaxHelper(medidasUri, 'GET').done(function (data) {
                self.medidas(data);
            });
        }

    
        // Fetch the initial data.
        getAllDevices();
    };

    ko.applyBindings(new ViewModel());
