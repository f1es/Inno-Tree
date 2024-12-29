import axios from "axios";

const URL = "http://localhost:5000";

const HEADERS = {
  "ngrok-skip-browser-warning": "1",
};

export const fetchDecoration = async (decorationId) => {
  const response = await axios.get(`${URL}/api/decorations/${decorationId}`, {
    headers: HEADERS,
  });

  return response.data;
};

export const fetchDecorations = async () => {
  const response = await axios.get(`${URL}/api/decorations`, {
    headers: HEADERS,
  });

  return response.data;
};

export const deleteDecoration = async (decorationId) => {
  await axios.delete(`${URL}/api/decorations/${decorationId}`);
};

export const createDecoration = async (author, message, type, x, y) => {
  await axios.post(`${URL}/api/decorations`, {
    author: author,
    message: message,
    type: type,
    x: x,
    y: y,
  });
};

export const updateDecoration = async (
  decorationId,
  author,
  message,
  type,
  x,
  y
) => {
  await axios.put(`${URL}/api/decorations/${decorationId}`, {
    author: author,
    message: message,
    type: type,
    x: x,
    y: y,
  });
};
