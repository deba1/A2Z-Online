import "./login.css";
import { Form, Input, Checkbox, Button, Row, Col } from "antd";
import Logo from "../../../../assets/Logo/Logo.png";
import Image from "../../../../assets/Image/Login.png";

function Login() {
  return (
    <div>
      <div className="container">
        <div className="purplecard">
          <div className="innercontent">
            <div className="logo">
              <img src={Logo} alt="Company Logo" />
            </div>
            <div className="image">
              <img src={Image} alt="Login Image" />
            </div>
          </div>
        </div>
        <div className="whitecard">
          <div className="roundtitle">Welcome Back</div>
          <div className="innercontent">
            <div className="head">
              <h1>Login your account</h1>
            </div>
            <Form layout="vertical">
              <p>Username or Email</p>
              <Input bordered={false} />
            </Form>
            <Form layout="vertical">
              <p>Password</p>
              <Input bordered={false} />
            </Form>
            <Form>
              <Form.Item
                name="remember"
                valuePropName="checked"
                wrapperCol={{ offset: 0, span: 12 }}
              >
                <Checkbox>Remember me</Checkbox>
              </Form.Item>
              <Form.Item wrapperCol={{ offset: 6, span: 16 }}>
                <Button type="primary">Login</Button>
              </Form.Item>
            </Form>
            <Form>
              <Row>
                <Col span={12}>
                  {" "}
                  <a href="#">Forget Password?</a>
                </Col>
                <Col className="rightallign" span={12}>
                  <a href="#">Create Account</a>
                </Col>
              </Row>
            </Form>
            <div className="line-container">
              <div className="line"></div>
              <p>Or Direct Login With</p>
              <div className="icons">
              <a href="www.facebook.com">
                <svg
                  id="facebook"
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 54.697 53.219"
                >
                  <ellipse
                    id="Ellipse_2"
                    data-name="Ellipse 2"
                    cx="27.348"
                    cy="26.609"
                    rx="27.348"
                    ry="26.609"
                    transform="translate(0 0)"
                    fill="#3b5998"
                  />
                  <path
                    id="Path_10"
                    data-name="Path 10"
                    d="M53.447,39.4H48.615V57.1H41.294V39.4H37.812V33.176h3.482V29.15c0-2.879,1.368-7.387,7.386-7.387l5.423.023v6.039H50.168a1.49,1.49,0,0,0-1.553,1.7v3.661h5.471Z"
                    transform="translate(-18.832 -11.728)"
                    fill="#fff"
                  />
                </svg>
              </a>
              <a href="www.google.com">
                <svg
                  id="google-icon"
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 53.076 54.159"
                >
                  <path
                    id="Path_11"
                    data-name="Path 11"
                    d="M156.546,112.3a23.205,23.205,0,0,0-.572-5.536H130.55V116.81h14.924a13.233,13.233,0,0,1-5.536,8.786l-.051.336,8.039,6.228.557.056c5.115-4.724,8.064-11.674,8.064-19.919"
                    transform="translate(-103.47 -84.616)"
                    fill="#4285f4"
                  />
                  <path
                    id="Path_12"
                    data-name="Path 12"
                    d="M38.116,178.094c7.311,0,13.449-2.407,17.933-6.559l-8.545-6.62a16.027,16.027,0,0,1-9.388,2.708A16.3,16.3,0,0,1,22.711,156.37l-.318.027-8.359,6.469-.109.3a27.06,27.06,0,0,0,24.191,14.924"
                    transform="translate(-11.037 -123.935)"
                    fill="#34a853"
                  />
                  <path
                    id="Path_13"
                    data-name="Path 13"
                    d="M11.674,88.955a16.671,16.671,0,0,1-.9-5.356,17.518,17.518,0,0,1,.872-5.356l-.015-.359L3.165,71.312l-.277.132a27.023,27.023,0,0,0,0,24.312l8.786-6.8"
                    transform="translate(0 -56.52)"
                    fill="#fbbc05"
                  />
                  <path
                    id="Path_14"
                    data-name="Path 14"
                    d="M38.116,10.471A15.008,15.008,0,0,1,48.587,14.5l7.642-7.462A26.018,26.018,0,0,0,38.116,0,27.06,27.06,0,0,0,13.925,14.924l8.756,6.8A16.369,16.369,0,0,1,38.116,10.471"
                    transform="translate(-11.037 0)"
                    fill="#eb4335"
                  />
                </svg>
              </a>
              </div>
              
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Login;
