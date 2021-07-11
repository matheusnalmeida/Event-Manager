import React from "react";
import PageNotFound from "../../assets/PageNotFound.gif";
import "./NotFound.css";

export default function NotFound() {
  return (
    <>
      <div className="notfound">
        <img alt='' src={PageNotFound} />
      </div>
    </>
  );
}
