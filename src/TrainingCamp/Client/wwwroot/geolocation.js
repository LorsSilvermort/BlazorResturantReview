function getLocation(instance) {
    if (navigator.geolocation) {
        
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        return;
    }

function showPosition(position) {
    instance.invokeMethod('SetCoordinates', position.coords.longitude.toString(), position.coords.latitude.toString());
    }
}