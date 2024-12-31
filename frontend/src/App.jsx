import React, { useEffect, useState, useRef } from "react";
import { Modal, Image, Typography } from "antd";
import Decoration from "./components/decoration.jsx";
import DecorationForm from "./components/DecorationForm.jsx";
import {
  fetchDecoration,
  fetchDecorations,
  createDecoration,
  deleteDecoration,
  updateDecoration,
} from "./ApiRequests.js";
import confetti from "canvas-confetti";

function App() {
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [decorations, setDecorations] = useState([]);
  const [coordinates, setCoordinates] = useState({ x: 0, y: 0 });

  const [isEdit, setIsEdit] = useState(false);
  const [editId, setEditId] = useState("");
  const [initialValues, setInitialValues] = useState({});

  const intervalRef = useRef(null);

  useEffect(() => {
    refreshDecorations();

    intervalRef.current = setInterval(() => {
      launchConfetti(0.2, 0.5);
      launchConfetti(0.8, 0.5);
    }, 2500);

    return () => clearInterval(intervalRef.current);
  }, []);

  const launchConfetti = (x, y) => {
    confetti({
      particleCount: 100,
      spread: 70,
      origin: { x: x, y: y },
    });
  };

  const refreshDecorations = async () => {
    const data = await fetchDecorations();
    setDecorations(data);
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

      await updateDecoration(
        editId,
        values.author,
        values.message,
        values.type,
        decoration.x,
        decoration.y
      );
    } else {
      await createDecoration(
        values.author,
        values.message,
        values.type,
        coordinates.x,
        coordinates.y
      );
    }

    await refreshDecorations();
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
          src={"christmas-tree.webp"}
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
          refreshDecorations={refreshDecorations}
          clickEvent={handleMouseClick}
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
