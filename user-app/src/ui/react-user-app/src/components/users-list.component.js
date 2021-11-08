import React, { Component } from "react";
import { connect } from "react-redux";
import {
  retrieveUsers,
  findByFirstName,
  deleteAllUsers,
} from "../actions/users";
import { Link } from "react-router-dom";

class UsersList extends Component {
  constructor(props) {
    super(props);
    //this.onChangeSearchFirstName = this.onChangeSearchFirstName.bind(this);
    this.refreshData = this.refreshData.bind(this);
    this.setActiveUser = this.setActiveUser.bind(this);
    this.findByFirstName = this.findByFirstName.bind(this);
    this.removeAllUsers = this.removeAllUsers.bind(this);

    this.state = {
      currentUser: null,
      currentIndex: -1,
      searchFirstName: "",
    };
  }

  componentDidMount() {
    this.props.retrieveUsers();
  }

  onChangeSearchFirstName(e) {
    const searchFirstName = e.target.value;

    this.setState({
      searchFirstName: searchFirstName,
    });
  }

  refreshData() {
    this.setState({
      currentUser: null,
      currentIndex: -1,
    });
  }

  setActiveUser(user, index) {
    this.setState({
      currentUser: user,
      currentIndex: index,
    });
  }

  removeAllUsers() {
    this.props
      .deleteAllUsers()
      .then((response) => {
        console.log(response);
        this.refreshData();
      })
      .catch((e) => {
        console.log(e);
      });
  }

  findByFirstName() {
    this.refreshData();

    this.props.findUsersByFirstName(this.state.searchFirstName);
  }

  render() {
    const { currentUser, currentIndex } = this.state;
    const { users } = this.props;

    return (

      <div className = "container" >
        <div className="row">
          <div className="col-md-6">


            <h2>User Records</h2>
            <p>The records below consist's of user of your department:</p>
            <table className="table table-bordered">
              <thead>
                <tr>
                  <th>#S.I</th>
                  <th>Name</th>

                  <th>Email Id</th>
                  <th>Gender</th>
                  <th>Action</th>
                </tr>
              </thead>
              <tbody>
                {users &&
                  users.map((user, index) => (

                    <tr
                      className={
                        (index === currentIndex ? "active" : "")
                      }
                      onClick={() => this.setActiveUser(user, index)}
                      key={index}
                    >
                      <td>{user.id}
                      </td>
                      <td>{user.firstName} {user.lastName}
                      </td>

                      <td>{user.emailId}
                      </td>
                      <td>{user.gender}
                      </td>
                      <td>
                       <a className="text-decoration-none"> View</a>
                      </td>
                    </tr>


                  ))}



              </tbody>
            </table>

             
           {/* <button
              className="m-3 btn btn-sm btn-danger"
              onClick={this.removeAllUsers}
            >
               Remove All 
          </button>*/}
          </div>

          
          <div className="col-md-1">

          </div>
          
          
          <div className="col-md-5">
            <br/>
            <br/>

            {currentUser ? (
              <div className="form-group">
                <h4>User</h4>
                <div className="label">
                  <label>
                    <strong>First Name:</strong>
                  </label>{" "}
                  {currentUser.firstName}
                </div>
                <div>
                  <label>
                    <strong>Last Name:</strong>
                  </label>{" "}
                  {currentUser.lastName}
                </div>
                <div>
                  <label>
                    <strong>Gender:</strong>
                  </label>{" "}
                  {currentUser.gender}
                </div>
                <div>
                  <label>
                    <strong>Email:</strong>
                  </label>{" "}
                  {currentUser.emailId}
                </div>
                <div>
                  <label>
                    <strong>Status:</strong>
                  </label>{" "}
                  {currentUser.published ? "Active" : "In Active"}
                </div>

                <Link
                  to={"/Users/" + currentUser.id}
                  className="badge badge-warning"
                >
                  Edit
              </Link>
              </div>
            ) : (
                <div>
                  <br />
                  {/* <p>Please click on a User...</p> */}
                </div>
              )}
          </div>
        </div>
    </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    users: state.users,
  };
};

export default connect(mapStateToProps, {
  retrieveUsers,
  findByFirstName,
  deleteAllUsers,
})(UsersList);
