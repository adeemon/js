class Storage {
    constructor() {
        this.dataArray = [];
        this.idCounter = 0;
    }

    add(inputObject) {
        inputObject.id = this.idCounter;
        this.dataArray.push(inputObject);
        this.idCounter = this.idCounter + 1;
    }

    getById(inputId) {
        if (this.dataArray[inputId].hasOwnProperty(id)) {
            return this.dataArray[inputId]
        } else {
            return null
        }
    }

    getAll() {
        return this.dataArray;
    }

    deleteById(idOfDeleted) {
        if (this.dataArray[idOfDeleted]) {
            return this.dataArray.splice(idOfDeleted, 1);
        } else {
            console.log("Wrong ID");
            return null;
        }
    }

    updateById(idOfUpdated, inputObject) {
        if (this.dataArray[idOfUpdated]) {
            let updatedObject = this.dataArray[idOfUpdated];
            for (let key in inputObject) {
                if (key !== "id") {
                    console.log(updatedObject[key], inputObject[key])
                    updatedObject[key] = inputObject[key];
                }
            }
        } else {
            console.log("Wrong ID");
        }
    }

    replaceById(replacedId, newObject) {
        if (this.dataArray[replacedId]) {
            newObject.id = replacedId;
            this.dataArray[replacedId] = newObject;
        } else {
            console.log("Wrong replacing ID")
        }
    }
}
