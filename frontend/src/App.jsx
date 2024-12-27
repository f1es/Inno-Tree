import React, { useEffect, useState } from "react";
import { Modal } from "antd";
import Decoration from "./components/decoration.jsx";
import DecorationForm from "./components/DecorationForm.jsx";
import axios from "axios";

function App() {
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [decorations, setDecorations] = useState([]);
  const [coordinates, setCoordinates] = useState({ x: 0, y: 0 });

  const [isEdit, setIsEdit] = useState(false);
  const [editId, setEditId] = useState("");

  useEffect(() => {
    fetchDecorations();
  }, []);

  const fetchDecorations = () => {
    axios.get("http://localhost:5000/api/decorations").then((response) => {
      setDecorations(response.data);
    });
  };

  const deleteDecoration = (decorationId) => {
    axios
      .delete(`http://localhost:5000/api/decorations/${decorationId}`)
      .then((response) => {
        fetchDecorations();
      });
  };

  const createDecoration = (author, message, type, x, y) => {
    axios
      .post("http://localhost:5000/api/decorations", {
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
      .put(`http://localhost:5000/api/decorations/${decorationId}`, {
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

  const handleClick = (event) => {
    if (isModalVisible) return;

    setCoordinates({ x: event.clientX - 50, y: event.clientY - 50 });

    setIsEdit(false);

    showModal();
  };

  const handleUpdate = (decorationId) => {
    if (isModalVisible) return;

    setIsEdit(true);
    setEditId(decorationId);

    showModal();
  };

  const handleSubmit = (values) => {
    if (isEdit) {
      updateDecoration(
        editId,
        values.author,
        values.message,
        values.type,
        coordinates.x,
        coordinates.y
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
  };

  return (
    <div
      onClick={handleClick}
      style={{
        height: "90vh",
        width: "95vw",
        position: "relative",
      }}
    >
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
          handleUpdate={handleUpdate}
        />
      ))}
      <Modal
        title="Leave your message"
        open={isModalVisible}
        onCancel={handleCancel}
        footer={null}
      >
        <DecorationForm handleSubmit={handleSubmit} />
      </Modal>
    </div>
  );
}

export default App;
