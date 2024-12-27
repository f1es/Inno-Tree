import { Popover, Image, Button, Flex } from "antd";
import axios from "axios";

function Decoration({
  decorationId,
  x,
  y,
  author,
  message,
  type,
  handleDelete,
  handleUpdate,
}) {
  const pictures = {
    "red-ball": "public\\red-ball.png",
    "blue-ball": "public\\blue-ball.png",
    bell: "public\\bell.png",
    wreath: "public\\wreath.png",
  };

  const contentStyle = {
    whiteSpace: "pre-wrap",
    maxWidth: "400px",
  };

  const content = (
    <div style={contentStyle}>
      <p>{message}</p>
    </div>
  );

  const positionStyle = {
    position: "absolute",
    left: `${x}px`,
    top: `${y}px`,
  };

  return (
    <div style={positionStyle}>
      <Popover
        content={
          <div style={contentStyle}>
            <Flex vertical gap={12}>
              <p>{message}</p>
              <Flex gap={6}>
                <Button
                  onClick={(event) => {
                    event.stopPropagation();
                    handleDelete(decorationId);
                  }}
                >
                  <p>Delete</p>
                </Button>
                <Button
                  onClick={(event) => {
                    event.stopPropagation();
                    handleUpdate(decorationId);
                  }}
                >
                  <p>Edit</p>
                </Button>
              </Flex>
            </Flex>
          </div>
        }
        title={author}
        width={100}
        maxWidth={200}
      >
        <Image width={100} height={100} src={pictures[type]} preview={false} />
      </Popover>
    </div>
  );
}

export default Decoration;