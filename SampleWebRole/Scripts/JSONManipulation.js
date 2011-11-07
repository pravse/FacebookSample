function DebugPrintJSON(JSONObject, tabLevel) {
    var printString = "";
    /***
    for (prop in JSONObject) {
    returnString += "\t" + prop + ":" + JSONObject[prop] + "\n";
    }
    ***/
    if (typeof JSONObject == 'object') {
        printString += "{ \n";
        $.each(JSONObject, function (key, value) {
            printString += GetTabString(tabLevel) + key + ":\t" + DebugPrintJSON(value, tabLevel + 1) + "\n";
        });
        printString += GetTabString(tabLevel) + " } \n";
    }
    else {
        printString += JSONObject;
    }
    return printString;
};


