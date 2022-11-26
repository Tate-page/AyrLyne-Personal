let OverviewMap;
let PinArray = [];
let polyLineArray = [];
function initOverviewMap() {
    var latlng = new google.maps.LatLng(44.512788990239144, -115.1808773416622);
    var options = {
        zoom: 3,
        center: latlng,
        mapTypeId: 'terrain'
    };
    OverviewMap = new google.maps.Map(document.getElementById("OverviewMap"), options);
}

function initOverviewLargeAirports(airport) {
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
    
    marker.setMap(OverviewMap);
    marker.addListener('click', (e) => { editSelectedAirport(marker.title) });
    PinArray.push(marker);
}

function initOverviewMediumAirports(airport) {
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
    
    marker.setMap(OverviewMap);
    marker.addListener('click', (e) => { editSelectedAirport(marker.title) });
    PinArray.push(marker);
}

function initAirportConnections(connection) {
    const flightPlanCoordinates = [
        { lat: connection.airport1.latitude, lng: connection.airport1.longitude },
        { lat: connection.airport2.latitude, lng: connection.airport2.longitude },
    ];

    const flightPath = new google.maps.Polyline({
        path: flightPlanCoordinates,
        geodesic: true,
        strokeColor: "#FF0000",
        strokeOpacity: 1.0,
        strokeWeight: 2,
    });
    flightPath.setMap(OverviewMap);

    polyLineArray.push(flightPath);
}

function editSelectedAirport(airport) {
    
    DotNet.invokeMethodAsync("AyrLyne-Personal", 'updateSelectedAirport', airport)
}

