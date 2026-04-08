from flask import Flask
import threading
import time

app = Flask(__name__)

ready = False

@app.route("/liveness")
def liveness():
    return "Alive", 200


@app.route("/readiness")
def readiness():
    return ("Ready", 200) if ready else ("Not Ready", 500)


def set_ready():
    global ready
    time.sleep(15)   # simulate startup delay
    ready = True


if __name__ == "__main__":
    threading.Thread(target=set_ready).start()
    app.run(host="0.0.0.0", port=8080)