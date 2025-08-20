// Listen for messages from the Angular app
window.addEventListener("message", (event) => {
  if (event.source !== window) return;

  if (event.data.type && event.data.type === "XPOS_REQUEST") {
    console.log('CONTENT SEND MESSAGE REQUEST', event.data.payload)
    chrome.runtime.sendMessage(
      { type: "show-qr", payload: event.data.payload },
      (response) => {
        window.postMessage(
          { type: "XPOS_RESPONSE", response },
          "*"
        );
      }
    );
  }
});
