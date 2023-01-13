let OverviewMap;
let PinArray = [];
let LargePinArray = [];
let MediumPinArray = [];
let polyLineArray = [];

function initOverviewMap() {
    //all paths are being displayed twice
    var latlng = new google.maps.LatLng(52.183360, -105.654249);
    var options = {
        zoom: 3,
        center: latlng,
        mapTypeId: 'terrain'
    };
    OverviewMap = new google.maps.Map(document.getElementById("OverviewMap"), options);
    OverviewMap.setOptions({ disableDefaultUI: true });
}

function initOverviewLargeAirport(airport) {
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(airport.latitude, airport.longitude),
        OverviewMap,
        title: airport.airportID.toString() ,
        icon: {
            size: new google.maps.Size(25, 25),
            scaledSize: new google.maps.Size(25, 25),
            url: '/Images/largeAirport.png'
        },
    });
    marker.addListener('click', (e) => { selectMarker(marker) });
    LargePinArray.push(marker);
    PinArray.push(marker);
}

function initOverviewMediumAirport(airport) {
    if (airport.airportID == undefined) {
        console.log("hi");
    }
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(airport.latitude, airport.longitude),
        OverviewMap,
        title: airport.airportID.toString(),
        icon: {
            size: new google.maps.Size(20, 20),
            scaledSize: new google.maps.Size(20, 20),
            url: '/Images/mediumAirport.png'
        },
    });
    marker.addListener('click', (e) => { selectMarker(marker) });
    MediumPinArray.push(marker);
    PinArray.push(marker);
}



function initAirportConnection(connection) {

    //if the companion connection has already rendered do not initialize it
    temp = polyLineArray.filter(function (conn) {
        return conn.airportID1 == connection.airportID2 && conn.airportID2 == connection.airportID1;
    });
    if (temp[0] == null) {
        pos1 = new google.maps.LatLng(connection.airport1.latitude, connection.airport1.longitude);
        pos2 = new google.maps.LatLng(connection.airport2.latitude, connection.airport2.longitude);
        const flightPlanCoordinates = [
            pos1,
            pos2,
        ];

        const flightPath = new google.maps.Polyline({
            path: flightPlanCoordinates,
            geodesic: true,
            strokeColor: "#FFFFFF",
            strokeOpacity: 1.0,
            strokeWeight: 2,
            title: connection.airportConnectionID.toString(),
        });
        polyLineArray.push(flightPath);
    }
    
}

//removeMarkerInOverviewMapByID
function unRenderMarkerInOverviewMapByID( id) {
    temp = PinArray.filter(a => a.title == id)
    temp[0].setMap(null);
}

//id for connection might not exist in js
function unRenderLineInOverviewMapByID( id) {
    temp = polyLineArray.filter(ac => ac.title == id)
    temp[0].setMap(null);
}


function renderMarkerInOverviewMapByID(id) {
    temp = PinArray.filter(a => a.title == id)
    temp[0].setMap(OverviewMap);
}

//id might not exist in js side
function renderLineInOverviewMapByID(id) {
    temp = polyLineArray.filter(a => a.title == id)
    temp[0].setMap(OverviewMap);
}


//new functions for airport connections
function renderLineInOverviewByCompanionAirportConnections(conn, companionConnection) {

    temp = polyLineArray.filter(line => (line.title == conn.airportConnectionID || line.title == companionConnection));
    temp[0].setMap(OverviewMap);
}

function unrenderLineInOverviewByCompanionAirportConnections(conn, companionConnection) {

    temp = polyLineArray.filter(line => (line.title == conn.airportConnectionID || line.title == companionConnection));
    temp[0].setMap(null);
}

let selectedAirport;

/*airport*/
function selectMarker(airport) {
    //reset previous marker

    
    if (selectedAirport != null) {
        let temp = LargePinArray.filter(m => m.title == airport.title);
        if (temp == null) {//it is a medium airport
            selectedAirport.setIcon({
                size: new google.maps.Size(20, 25),
                scaledSize: new google.maps.Size(20, 25),
                url: '/Images/mediumAirport.png'
            });
        } else {
            selectedAirport.setIcon({
                size: new google.maps.Size(20, 25),
                scaledSize: new google.maps.Size(20, 25),
                url: '/Images/largeAirport.png'
            });
        }
    }
    

    //update new marker
    airport.setIcon({
        size: new google.maps.Size(20, 25),
        scaledSize: new google.maps.Size(20, 25),
        url: '/Images/selectedAirport.png'
    });
    
    selectedAirport = airport;

    
    DotNet.invokeMethodAsync("AyrLyne-Personal", 'selectAirport', airport.title)
}

let selectedAirportForAirportConnection = "Airport1";
function updateSelectedAirportForAirportConnectionOption(opt) {
    selectedAirportForAirportConnection = opt;
}

let wasAirportConnectionRenderedBeforeSelection;
function selectLineFromServer(id, boo) {
    selectedAirportConnection = polyLineArray.filter(ac => ac.title == id);
    selectedAirportConnection.setOptions({ strokeColor: "#FF0000" });
    wasAirportConnectionRenderedBeforeSelection = boo;
}

