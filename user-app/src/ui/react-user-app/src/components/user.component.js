import React, { Component } from "react";
import { connect } from "react-redux";
import { updateUser, deleteUser } from "../actions/users";
import UserDataService from "../services/user.service";

class User extends Component {
  constructor(props) {
    super(props);
    this.onChangeFirstName = this.onChangeFirstName.bind(this);
    this.onChangeLastName = this.onChangeLastName.bind(this);
    this.getUser = this.getUser.bind(this);
    this.updateStatus = this.updateStatus.bind(this);
    this.updateContent = this.updateContent.bind(this);
    this.removeUser = this.removeUser.bind(this);

    this.state = {
      currentUser: {
        id: null,
        firstName: "",
        lastName: "",
        status: false,
        gender: "",
        emailId: "",
        submitted: false,
        published: false,
      },
      message: "",
    };
  }

  componentDidMount() {
    this.getUser(this.props.match.params.id);
  }

  onChangeFirstName(e) {
    const firstName = e.target.value;

    this.setState(function (prevState) {
      return {
        currentUser: {
          ...prevState.currentUser,
          firstName: firstName,
        },
      };
    });
  }

  onChangeLastName(e) {
    const lastName = e.target.value;

    this.setState((prevState) => ({
      currentUser: {
        ...prevState.currentUser,
        lastName: lastName,
      },
    }));
  }

  getUser(id) {
    UserDataService.get(id)
      .then((response) => {
        this.setState({
          currentUser: response.data,
        });
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  }

  updateStatus(status) {
    var data = {
      id: this.state.currentUser.id,
      firstName: this.state.currentUser.firstName,
      lastName: this.state.currentUser.lastName,
      emailId: this.state.currentUser.emailId,
      gender: this.state.currentUser.gender,
      published: status,
    };

    this.props
      .updateUser(this.state.currentUser.id, data)
      .then((reponse) => {
        console.log(reponse);

        this.setState((prevState) => ({
          currentUser: {
            ...prevState.currentUser,
            published: status,
          },
        }));

        this.setState({ message: "The status was updated successfully!" });
      })
      .catch((e) => {
        console.log(e);
      });
  }

  updateContent() {
    this.props
      .updateUser(this.state.currentUser.id, this.state.currentUser)
      .then((reponse) => {
        console.log(reponse);
        
        this.setState({ message: "The User was updated successfully!" });
      })
      .catch((e) => {
        console.log(e);
      });
  }

  removeUser() {
    this.props
      .deleteUser(this.state.currentUser.id)
      .then(() => {
        this.props.history.push("/users");
      })
      .catch((e) => {
        console.log(e);
      });
  }

  render() {
    const { currentUser } = this.state;

    return (
      <div>
        {currentUser ? (
          <div className="edit-form" >
            <h4>User</h4>
            <form>
              <div className="form-group">
                <label htmlFor="firstName">First Name</label>
                <input
                  type="text"
                  className="form-control"
                  id="firstName"
                  value={currentUser.firstName}
                  onChange={this.onChangeFirstName}
                />
              </div>
              <div className="form-group">
                <label htmlFor="lastName">Last Name</label>
                <input
                  type="text"
                  className="form-control"
                  id="lastName"
                  value={currentUser.lastName}
                  onChange={this.onChangeLastName}
                />
              </div>
              <div className="form-group">
                <label htmlFor="emailId">Email ID</label>
                <input
                  type="text"
                  className="form-control"
                  id="emailId"
                  value={currentUser.emailId}
                  onChange={this.updateContent}
                />
              </div>
            
              <div className="form-group">
                <label htmlFor="gender">Gender</label>
                <input
                  type="text"
                  className="form-control"
                  id="gender"
                  value={currentUser.gender}
                  onChange={this.updateContent}
                />
              </div>

              <div className="form-group">
                <label>
                  <strong>Status:</strong>
                </label>
                {currentUser.status ? "True" : "false"}
              </div>
            </form>

            {currentUser.status ? (
              <button
                className="badge badge-primary mr-2"
                onClick={() => this.updateStatus(false)}
              >
                True
              </button>
            ) : (
              <button
                className="badge badge-primary mr-2"
                onClick={() => this.updateStatus(true)}
              >
                False
              </button>
            )}

            <button
              className="badge badge-danger mr-2"
              onClick={this.removeUser}
            >
              Delete
            </button>

            <button
              type="submit"
              className="badge badge-success"
              onClick={this.updateContent}
            >
              Update
            </button>
            <p>{this.state.message}</p>
          </div>
        ) : (
          <div>
            <br />
            <p>Please click on a User...</p>
          </div>
        )}
      </div>
    );
  }
}

export default connect(null, { updateUser, deleteUser })(User);
