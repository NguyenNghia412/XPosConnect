// Listen for messages from the Angular app
window.addEventListener("message", (event) => {
  if (event.source !== window) return;

  if (event.data.type && event.data.type === "XPOS_REQUEST") {
    console.log('CONTENT SEND MESSAGE REQUEST', event.data.payload)
    const type = event.data.payload.type;
    const data = event.data.payload.data;

    chrome.runtime.sendMessage(
      { type: type, payload: data },
      (response) => {
        window.postMessage(
          { type: "XPOS_RESPONSE", response },
          "*"
        );
      }
    );
  }
});
