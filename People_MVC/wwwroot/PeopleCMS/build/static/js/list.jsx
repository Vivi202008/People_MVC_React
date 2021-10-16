class list extends React.Component {
    constructor(props) {
        super(props)
    }


    render() {
        return (
            <div>
                <br />
                <h4 id='title'>React Peoplelist.</h4>
                <p>(click on tablehead "PersonID" or "Name" to sort them ascending)</p>
                <br />
                <RenderTable personlistdatastate={this.props.personlistdatastate} setPersonobjstate={this.props.setPersonobjstate} setViewPage={this.props.setViewPage} />
            </div>
        )
    }

}