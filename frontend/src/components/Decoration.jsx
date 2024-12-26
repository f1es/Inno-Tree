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
              <Button
                style={{
                  height: "30px",
                  width: "60px",
                  verticalAlign: "right",
                }}
                onClick={(event) => {
                  event.stopPropagation();
                  handleDelete(decorationId);
                }}
              >
                <p>Delete</p>
              </Button>
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
