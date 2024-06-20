const { JSDOM } = require("jsdom");
const fs = require("fs");
const path = require("path");

test("Login click Success Test", () => {
  const html = fs.readFileSync(
    path.resolve(__dirname, "../Frontend/Login.html"),
    "utf8"
  );
  const script = fs.readFileSync(
    path.resolve(__dirname, "../Frontend/Login.js"),
    "utf8"
  );
  const style = fs.readFileSync(
    path.resolve(__dirname, "../Frontend/Login.css"),
    "utf8"
  );

  const dom = new JSDOM(html, {
    runScripts: "dangerously",
    resources: "usable",
  });
  const scriptElement = dom.window.document.createElement("script");
  scriptElement.textContent = script;
  dom.window.document.body.appendChild(scriptElement);
  const styleElement = dom.window.document.createElement("style");
  styleElement.textContent = style;
  dom.window.document.head.appendChild(styleElement);


  dom.window.document.getElementById("mail").value = "John@gmail.com";
  dom.window.document.getElementById("password").value = "123456";
  dom.window.document.getElementById("button").click();
  const actual = dom.window.document.getElementById("isSuccess").innerHTML;
  expect(actual).toBe("Valid User");
});
test("Login click Fail Test", () => {
  const html = fs.readFileSync(
    path.resolve(__dirname, "../Frontend/Login.html"),
    "utf8"
  );
  const script = fs.readFileSync(
    path.resolve(__dirname, "../Frontend/Login.js"),
    "utf8"
  );

  const dom = new JSDOM(html, {
    runScripts: "dangerously",
    resources: "usable",
  });
  const scriptElement = dom.window.document.createElement("script");
  scriptElement.textContent = script;
  dom.window.document.body.appendChild(scriptElement);
  

  dom.window.document.getElementById("mail").value = "John@gmail.com";
  dom.window.document.getElementById("password").value = "12345";
  dom.window.document.getElementById("button").click();
  const actual = dom.window.document.getElementById("isSuccess").innerHTML;
  expect(actual).toBe("Invalid User");
});
