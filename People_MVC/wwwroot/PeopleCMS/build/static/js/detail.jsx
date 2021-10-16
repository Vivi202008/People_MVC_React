class Persondetails extends React.Component {
    constructor(props) {
        super(props)
    }
    personInfo() {
        return (
            <div id="#reactcontainer">
                <div id="reactwrapper">
                    <br />
                    <h4>Person Details:</h4>
                    <br />
                    PersonId: {this.props.personobj.personId}
                    <br />
                    Name: {this.props.personobj.personName}
                    <br />
                    PhoneNumber: {this.props.personobj.personPhoneNumber}
                    <br />
                    City: {this.props.personobj.city.cityName}
                    <br />
                    Country: {this.props.personobj.city.country.countryName}
                    <br />
                </div>
                <br />
                Languages:
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <select size="5" disabled multiple="multiple">
                    {this.props.personobj.personLanguages.map((listitem) => (
                        <option key={listitem.language.languageId} value={listitem.language.languageId}>{listitem.language.languageName}</option>
                    ))}
                </select>
                <br />
                <div>
                    <button id="optionBtnGray" onClick={() => this.props.setViewPage("peoplelisttable")}>Back to React Peoplelist</button>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <button id="optionBtnRed" onClick={(e) =>
                        window.confirm("Are you sure you wish to delete this person?") &&
                        onClickDeletePerson(this.props.personobj, this.props.setViewPage, this.props.loadDataFromServer)}>
                        Delete this Person
                    </button>
                </div>
            </div>

        )
    }


    render() {
        return (
            <div>
                {this.personInfo()}
            </div>
        )
    }

} // class end tag


function onClickDeletePerson(personobj, setViewPage, loadDataFromServer) {

    //var ajaxRequest = 
    $.post("/React/DeletePerson", { Id: personobj.personId }, function (data) {
        //$("#ajaxjson").html(data);
    })
        .done(function () {
            loadDataFromServer()
            setViewPage("peoplelisttable")
            document.getElementById("list").textContent = `Person: ${personobj.personName} with Id: ${personobj.personId}, is now deleted.`
        })
        .fail(function () {
            document.getElementById("list").textContent = `FAILED to Delete: ${personobj.personName}. (Does not exist).`
        })
        .always(function () {

        })


}
