import React, { Component } from "react";
import { connect } from "react-redux";
import { createUser } from "../actions/users";

class AddUser extends Component {
  constructor(props) {
    super(props);
    this.onChangefirstName = this.onChangefirstName.bind(this);
    this.onChangelastName = this.onChangelastName.bind(this);
    //this.emailId = this.onChangeEmail.bind(this);
    // this.gender = this.onChangeDescription.bind(this);
    // this.status = this.onChangeDescription.bind(this);
    this.saveUser = this.saveUser.bind(this);
    this.newUser = this.newUser.bind(this);

    this.state = {
      id: null,
      firstName: "",
      lastName: "",
      email: "",
      gender: "",
      status: false,

      submitted: false,
    };
  }

  onChangefirstName(e) {
    this.setState({
      firstName: e.target.value,
    });
  }

  onChangelastName(e) {
    this.setState({
      lastName: e.target.value,
    });
  }

  saveUser() {
    const { firstName, lastName, emailId, gender, status } = this.state;

    this.props
      .createUser(firstName, lastName, emailId, gender, status)
      .then((data) => {
        this.setState({
          id: data.id,
          firstName: data.firstName,
          lastName: data.lastName,
          status: data.status,
          gender: data.gender,
          emailId: data.emailId,
          submitted: true,
        });
        console.log(data);
      })
      .catch((e) => {
        console.log(e);
      });
  }

  newUser() {
    this.setState({
      id: null,
      firstName: "",
      lastName: "",
      status: false,
      gender: "",
      emailId: "",
      published: false,
      submitted: false,
    });
  }

  render() {
    return (
      <div className="submit-form">
        {this.state.submitted ? (
          <div>
            <h4>You submitted successfully!</h4>
            <button className="btn btn-success" onClick={this.newUser}>
              Add User
            </button>
          </div>
        ) : (
            <div>
              <div className="form-group">
                <label htmlFor="firstName">First Name</label>
                <input
                  type="text"
                  className="form-control"
                  id="firstName"
                  required
                  value={this.state.firstName}
                  onChange={this.onChangefirstName}
                  name="firstName"
                />
              </div>

              <div className="form-group">
                <label htmlFor="lastName">Last Name</label>
                <input
                  type="text"
                  className="form-control"
                  id="lastName"
                  required
                  value={this.state.lastName}
                  onChange={this.onChangelastName}
                  name="lastName"
                />
              </div>
              <div className="form-group">
                <label htmlFor="gender">Gender</label>
                <input
                  type="text"
                  className="form-control"
                  id="gender"
                  required
                  value={this.state.gender}
                  onChange={this.onChangegender}
                  name="gender"
                />
              </div>

              <div className="form-group">
                <label htmlFor="emailId">Email id</label>
                <input
                  type="text"
                  className="form-control"
                  id="emailId"
                  required
                  value={this.state.emailId}
                  onChange={this.onChangeemailId}
                  name="emailId"
                />
              </div>

              <div className="form-group">
                <label htmlFor="status">Status</label>
                <input
                  type="text"
                  className="form-control"
                  id="status"
                  required
                  value={this.state.status}
                  onChange={this.onChangestatus}
                  name="status"
                />
              </div>



              <button onClick={this.saveUser} className="btn btn-success">
                Submit
            </button>
            </div>
          )}
      </div>
    );
  }
}

export default connect(null, { createUser })(AddUser);
