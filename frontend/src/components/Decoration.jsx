import { Popover, Image, Button, Flex } from "antd";
import { useEffect, useState } from "react";

function Decoration({
  decorationId,
  x,
  y,
  author,
  message,
  type,
  handleDelete,
  handleUpdate,
  refreshDecorations,
  clickEvent,
}) {
  const [isPopoverVisible, setIsPopOverVisible] = useState(false);

  useEffect(() => {
    setIsPopOverVisible(false);
  }, [clickEvent]);

  const pictures = {
    "red-ball": "red-ball.webp",
    "blue-ball": "blue-ball.webp",
    bell: "bell.webp",
    wreath: "wreath.webp",
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
    left: `${x}vw`,
    top: `${y}vh`,
    width: "auto",
    height: "auto",
  };

  return (
    <div
      style={positionStyle}
      onClick={(event) => {
        event.stopPropagation();
      }}
    >
      <Popover
        open={isPopoverVisible}
        trigger={"click"}
        onClick={(event) => {
          event.stopPropagation();
          setIsPopOverVisible(!isPopoverVisible);
        }}
        content={
          <div style={contentStyle}>
            <Flex vertical gap={12}>
              <p>{message}</p>
              <Flex gap={6}>
                <Button
                  onClick={async (event) => {
                    event.stopPropagation();
                    await handleDelete(decorationId);
                    await refreshDecorations();
                  }}
                >
                  <p>Delete</p>
                </Button>
                <Button
                  onClick={(event) => {
                    event.stopPropagation();
                    handleUpdate(decorationId);
                    setIsPopOverVisible(false);
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
