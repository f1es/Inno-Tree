import React, { useEffect, useState } from "react";
import { Modal, Image, Typography } from "antd";
import Decoration from "./components/decoration.jsx";
import DecorationForm from "./components/DecorationForm.jsx";
import axios from "axios";

function App() {
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [decorations, setDecorations] = useState([]);
  const [coordinates, setCoordinates] = useState({ x: 0, y: 0 });

  const [isEdit, setIsEdit] = useState(false);
  const [editId, setEditId] = useState("");
  const [initialValues, setInitialValues] = useState({});

  const [url, setUrl] = useState("http://localhost:5000");

  useEffect(() => {
    fetchDecorations();
  }, []);

  const fetchDecoration = async (decorationId) => {
    const response = await axios.get(`${url}/api/decorations/${decorationId}`);

    return response.data;
  };

  const fetchDecorations = () => {
    axios
      .get(`${url}/api/decorations`, {
        headers: {
          "ngrok-skip-browser-warning": "1",
        },
      })
      .then((response) => {
        setDecorations(response.data);
      });
  };

  const deleteDecoration = (decorationId) => {
    axios.delete(`${url}/api/decorations/${decorationId}`).then((response) => {
      fetchDecorations();
    });
  };

  const createDecoration = (author, message, type, x, y) => {
    axios
      .post(`${url}/api/decorations`, {
        author: author,
        message: message,
        type: type,
        x: x,
        y: y,
      })
      .then((response) => {
        fetchDecorations();
      });
  };

  const updateDecoration = (decorationId, author, message, type, x, y) => {
    axios
      .put(`${url}/api/decorations/${decorationId}`, {
        author: author,
        message: message,
        type: type,
        x: x,
        y: y,
      })
      .then((response) => {
        fetchDecorations();
      });
  };

  const handleMouseClick = (event) => {
    if (isModalVisible) return;

    const xPx = event.clientX - 50;
    const yPx = event.clientY - 5;

    const xVw = Math.round((xPx / window.innerWidth) * 100);
    const yVh = Math.round((yPx / window.innerHeight) * 100);

    setCoordinates({ x: xVw, y: yVh });

    setIsEdit(false);
    setInitialValues({});

    showModal();
  };

  const handleDecorationUpdate = (decorationId) => {
    if (isModalVisible) return;

    setIsEdit(true);
    setEditId(decorationId);

    const decorationToEdit = decorations.find(
      (decoration) => decoration.id == decorationId
    );
    setInitialValues(decorationToEdit);

    showModal();
  };

  const handleSubmit = async (values) => {
    if (isEdit) {
      const decoration = await fetchDecoration(editId);

      updateDecoration(
        editId,
        values.author,
        values.message,
        values.type,
        decoration.x,
        decoration.y
      );
    } else {
      createDecoration(
        values.author,
        values.message,
        values.type,
        coordinates.x,
        coordinates.y
      );
    }

    setIsModalVisible(false);
  };

  const showModal = () => {
    if (isModalVisible) return;
    setIsModalVisible(true);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
    setInitialValues({});
  };

  return (
    <div
      onClick={handleMouseClick}
      style={{
        height: "90vh",
        width: "95vw",
      }}
    >
      <div>
        <Typography.Title
          style={{
            color: "red",
            position: "absolute",
            marginTop: "90vh",
            marginLeft: "1vw",
            fontSize: "7.5vh",
            fontWeight: "700",
            opacity: "75%",
          }}
        >
          Inno Christmas Tree
        </Typography.Title>
      </div>
      <div>
        <img
          src={"christmas-tree.png"}
          style={{
            position: "absolute",
            height: "90vh",
            marginTop: "5vh",
            marginLeft: "32vw",
            marginRight: "auto",
          }}
        ></img>
      </div>

      {decorations.map((component) => (
        <Decoration
          decorationId={component.id}
          key={component.id}
          x={component.x}
          y={component.y}
          author={component.author}
          message={component.message}
          type={component.type}
          handleDelete={deleteDecoration}
          handleUpdate={handleDecorationUpdate}
        />
      ))}
      <Modal
        title="Write your message"
        open={isModalVisible}
        onCancel={handleCancel}
        footer={null}
      >
        <DecorationForm
          handleSubmit={handleSubmit}
          initialValues={initialValues}
          isEdit={isEdit}
        />
      </Modal>
    </div>
  );
}

export default App;
